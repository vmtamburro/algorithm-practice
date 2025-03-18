### REST (Representational State Transfer)
* HTTP methods (GET, POST, PUT, DELETE) with JSON or XML
* Traditional Web API's, CRUD, Microservices
* Pros: Simple, widely used. Staeless. Works well for Public API's
* Cons: Inefficient for real-time applciations. Overhead due to repeated requests and responses

### gRPC (Google Remote Procedure Call)
* High performance microservices, internal service-to-service communication
* Uses protocol buffers (protobuf) instead of JSON for smaller, faster messages
* Pros: Binary format (protobuf) is faster and more efficient than JSON. Supports streaming (client, server, bidirectional). Stronger Type Safety
* Cons: More complex than REST. Not as human-readable as JSON. Limited browser support.
* Use when speed and efficiency matter. Low latency, high throughput. For inter-service communication in a microservices architecture.

### WebSockets
* Best for real-time communnication (chat apps, live updates, stock prices)
* Full-duplex connection. (Client and server can sned messages at an y time)
* Pros: Persistent connection (no need for repeated requests). Low latency
* Cons: More complex than REST. Tricky to scale. Requires sticky sessions or WebSocket-aware load balancers.
* Use for real-time applications like chat dashboards, multi-player games, stock tickers.

### Message Queues (Kafka, RabbitMQ, AWS SQS, Google PubSub)
* Async event-driven architctures
* USes Producer -> Queue > Consumer Model
* Pros: Decouple Services - sender doesn't need to wait for a response. Ensures reliability - messages are processed even if a service is temporarily down.
* Cons: Higher complexity than direct API calls. Needs monitoring to handle failures properly.
* Processing large-scale events (log aggregation, analytics, background jobs). Decouplign microservices (an order system sending events to a payment service)


### What to use when
* REST -> Simple API's CRUD Operations
* gRPC -> High Performance, microservice-to-microservice operations.
* WebSockets -> Real-time applications like chat, live feeds, and notifications.
* Messaging Queues -> Event-driven systems, background processing, and large-scale distributed systems.