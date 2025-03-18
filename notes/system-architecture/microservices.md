## Microservices

### Overview
* Independence
* Single Responsibility
* Scalability
* Decentralized Data Management
* Resilience & Fault Isolation
* Communication via APIs

### Versus Monolithic
* Each service is deployed independently
* Scaling scales specific services
* Can use different languages for different services
* Failures are isolated to specific services
* Faster (teams work in parallel)

### Database Strategy
* Database per Service
* Each swervice manages its own data
* Improves data isolation
* Event-driven sync when services need shared data