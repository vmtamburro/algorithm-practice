## System Design and Architecture

### System Design Fundamentals
* Scalabiltiy
* Availability
* Consistency - synchronization across components
* Latency
* Throughput

### High-Level System Design
* Requirements - users, traffic, constraints
* Components - Core Services, Databases, APIs
* Data Storage - SQL vs NoSQL Databases
* Communication - REST, gRPC, WebSockets, Messaging Queues
* Handle Scalability & Load - Load balancing, caching, partitioning
* Security Considerations - Auth, encryption, DDoS protection

### DB and Storage
* SQL (relational) vs Non-SQL (non-relational)
    * SQL: ACID compliance, Structured Queries (MySQL, PostgreSQL)
        * Atomicity, Consistency, Isolation, Durability
    * NoSQL: High scalability, flexible schema (MongoDB, Cassandra)
* Sharding: distributing data across multiple db's
* Replication: Copying data for high availbility 
* Indexing: Improves query performance

### Load Balancing & Caching
* Load balancers: distribute traffic accross servers (Nginx, AWS ALB)
* CDN (Content Delviery Network): Improves load times for static assets
* Caching Strategies:
  * Client-Side Caching (Browser, CDN)
  * Server-side Caching (Redis, Memached)
  * Database Caching (Query caching, materialized views)

### Messages, Queues, & Event Driven Architecture
* Kafka, RabbitMQ, AWS SQS for asynchronous processing
* Pub/Sub Model. Used for decoupling microservices

### Microservices & API Design
* Monolithic vs Microservices
  * Monolithic - easier to develop, harder to scale
  * Microservices - Scalable, fault-tolerant, but complex
* API Design Principles
  * RESTful APIs: Stateless, uses HTTP methods
  * gRPC: High-performance, uses Protobufs
  * WebSockets: Real-time bidirectional communication

### Security Considerations
* Authentication & Authorization: OAuth, JWT, API keys
* Data Encryption: At rest (AES) and in transit (TLS/SSL)
* DDoS Protection: Rate limiting, WAF (Web Application Firewall)
* Input Validation: Preventing SQL Injection, XSS, CSRF attacks

### Scalability & High Availability
* Vertical Scaling (Scaling Up): Increasing CPU/RAM on a single server
* Horizontal Scaling (Scaling Out): Adding More Servers

### Common System Design Questions
1. Design a URL Shortener
2. Design a Rate Limiter for APIs
3. Design a Distributed File Storage System
4. Design a Real-Time Messaging App
5. Design a Recommendation System