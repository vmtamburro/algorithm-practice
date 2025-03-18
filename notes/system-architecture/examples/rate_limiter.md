# Design a Rate Limiter for APIs

#### Problem Statement
Design a rate limiter that restricts the number of API requests a user can make within a given time period to prevent abuse and ensure fair resource usage.

### 1. Clarify Requirements
Functional Requirements
* Limit the nuber of requests per user/IP within a time window
* Support different policies
  * 10 requests per second, 1000 requests per day
* Block excessive requests with HTTP 429 Too Many Requests
* Allow graceful handling (e.g. rate limit reset, exponential backoff)

Non-functional Requirements:
* Low-latency - the rate limiter should introduce minimal delay
* Scalability - should handle millions of requests per second across distributed systems
* High availability - Should not be a single point of failure.


### 2. Rate Limiting Algorithms
1. Token Bucket (Efficient, Burst Handling)
    * A "bucket" holds tokens 
        * 10 requests per second = 10 tokens per second
    * Every request takes a token; if the bucket is empty, the reuest is rejected
    * Tokens refill at a fixed rate
    * Good for: handling bursts of traffic smoothly
    * Implementation: Redis or an in-memory counter
2. Leaky Bucket (Smooth Request Rate)
    * Works like a queue: Requests enter, but are processed at a constant rate
    * Prevents sudden traffic spikes
    * Good for: Traffic shaping in network systems
3. Fixed Window Counter (Simple, can be unfair)
    * Count resets every time window (e.g. 100 requests per minute)
    * Problem: Users can send 100 requests in 1 second, then wait
4. Sliding Window Log (Precise, Expensive on Memory)
    * Stores a timestamp log of every request per user
    * Check past timestamps to allow or block requests
    * Downside: High memory usage in large-scale systems
5. Sliding Window Counter (Hybrid Approach, Efficient)
    * Fixes Fixed Window Unfairness by splitting time windows into smaller parts
      * Example: 100 requests per minute
        * Divide into 10 second windows
    * Efficient and used in Redis Lua scripts for performance

Best choice for API rate limiting: Token Bucket or Sliding Window Counter (scales wall & handles bursts)

### 3. High-Level Design
Components
* API Gateway (NGINX, Kong, AWS API Gateway) - First layer to enforce rate limits
* Rate Limiter Service - Tracks and enforces reuest limits
* Data Store (Redis, Memached, DynamoDB) - Stores request counters and timestamps
* Monitoring & Alerts - Logs blocked requests for analytics

### 4. Database Choice: Why Redis?
* Low Latency - Fast reads/writes
* Atomic Operations - Prevents race conditions in multi-threaded environments
* Expiration (TTL)  - Automatically clears old requests
* Distributed & Scalable - Can run across multiple instances


### 5. API Design and Implementation
Redis-based token bucket example (python)
```python
import time
import redis

redis_client = redis.Redis(host='localhost', port=6379, db=0)

class RateLimiter:
    def __init__(self, user_id, max_requests, time_window):
        self.user_id = user_id
        self.max_requests = max_requests
        self.time_window = time_window
        self.key = f"rate_limit:{self.user_id}"

    def is_allowed(self):
        # Atomic Redis transaction
        with redis_client.pipeline() as pipe:
            try:
                pipe.watch(self.key)
                current_count = redis_client.get(self.key)
                if current_count is None:
                    pipe.multi()
                    pipe.set(self.key, 1, ex=self.time_window)
                    pipe.execute()
                    return True
                elif int(current_count) < self.max_requests:
                    pipe.multi()
                    pipe.incr(self.key)
                    pipe.execute()
                    return True
                else:
                    return False  # Rate limit exceeded
            except redis.exceptions.WatchError:
                return False  # Handle race condition

# Example Usage
limiter = RateLimiter(user_id="123", max_requests=5, time_window=10)  # 5 requests per 10 seconds
if limiter.is_allowed():
    print("Request Allowed ✅")
else:
    print("Too Many Requests 🚫")

```

### 6. Scaling the Rate Limiter
* Distribute redis across multiple nodes (redis cluster)
* Deploy rate limiter at API Gateway (NGINX/Kong) instead of individual services
* Use a distributed messaging queue (Kafka, RabbitMQ) for handling burst traffic
* Implement a Circuit Breaker to protect services from overload

### 7. Handling Edge Cases & Attacks
* Bot protection: CAPTCHA for excessive requests
* IP-Based & User-Based Limits: different limits for anonymous vs logged in users
* Graceful Degradation: Use retry-after headers to tell users when to retry
* Distributed Systems: Keep rate limits consistent across multiple servers