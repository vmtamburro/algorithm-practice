## Design a URL Shortner
*Like bit.ly or TinyUrl*

### 1. Clarify Requirements
* Functional Requirements
  * User Enters a Long URL => Get a short URL
  * Clicking the short URL redirects to the original URL
  * Expired URLs should not work
  * Users should be able to see how many times their link was clicked (optional)
* Non-Functional Requirements
  * System should be highly available.
  * Should be able to handle millions of requests per day
  * Short URLs should be unique and fast to generate
  * System should be scalable and support **read-heavy workloads**

### 2. High-Level Design
* Components
  * API Layer: Accepts Long URLS, generates short URLs, handles redirects
  * Database: Stores mappings of short urls to long urls
  * Cache: Speeds up read operations
  * Load Balancer: Distributes traffic across multiple servers
  * Background Jobs: For Analytics (Counting Clicks)

### 3. URL Shortening Strategy
  * Base62 encoding (a-z, A-Z, 0-9) - converts an ID into a string
  * Hashing (MD5, SHA256) - creates collisions, so we may need a retry mechanism
  * UUID (universally unique id) - guarantees uniqueness, but longer to store
  * Example: Convert to the auto-increment ID (12345) to base62 (d3z)

### 4. Database Design

| Short URL | Long URL                              | Created At | Expiry Date | Clicks |
|-----------|---------------------------------------|------------|-------------|--------|
| d3z       | https://www.example.com/article123    | 2025-03-15 | NULL        | 10     |

* Relational DB
  * MySQL, PostgreSQL, SQL Server if ACID compliance is needed
  * NoSQL for high write throughput and horizontal scaling
* Otpimizations
  * Index on short url for fast lookups
  * Sharding
  * Read-Heavy Optimizations


### 5. Handling High Traffic & Scalability
* CDN (Content Delivery Network) - Cache Static Responses for faster redirects
* Load Balancers - Distribute traffic between API Servers
* Replication - Read replicas for high read throughput
* Rate Limiting (to prevent abuse) - Limit API requests per user/IP

### 6. Caching Strategy
* Cache Short -> Long URL mappings in Redis
* Use TTL (Time to Live) to remove unused entries


### 7. Analytics & Logging
* Store click counts, timestamps, referrer data in Kafka -> Big Query
* Show Analytics (how many people clicked a short url, and where they came from)

### 8. Failure & Fault Tolerance
* Database Replication - to prevent data loss
* Retries & Circuit Breakers - to prevent API failures
* Monitoring (Prometheus, Grafana) - Detect Issues Early

### 9. API Endpoints
```txt
POST /shorten  
Body: { "long_url": "https://www.example.com/article123" }  
Response: { "short_url": "https://short.ly/d3z" }

GET /d3z  
Response: 301 Redirect → "https://www.example.com/article123"

```




