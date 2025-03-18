# Real-Time Messaging App

### 1. Understanding Requirements
Functional Requirements
* Send and receive messages in real-time
* One-on-one and group messaging
* Message Delivery Status (Sent, Delivered, Read).
* Online/offline user presence
* Message History and persistence
* End-to-end encryption for security

Non-Functional Requirements
* Low latency (~miliseconds)
* High availability and fault tolerance
* Horizontal scalability (millions of users)
* Handle message ordering and delivery guarantees
* Efficient storage for message history

### 2. High-Level Architecture
Major Components
1. Client Apps (Mobile, Web, Desktop)
2. API Gateway and Load Balancer - Routes Requests to correct service
3. Authentication Service - Handles User Login, Sessions, and Security
4. Messaging Service - Core service handling message delivery, storage, and status updates
5. Databas (SQL/NoSQL) - Stores users, messages, and metadata
6. WebSockets Service - Maintains real-time connections for instant messaging
7. Push Notifications Service - Notifies users when a new message arrives
8. Media Storage (Cloud/S3) - Stores images, videos and files

### 3. Message Flow (How Messages are Sent & Received)
Sending a Message
1. User sends a message from their device
2. The client app encrypts the message and sends it to the API Gateway
3. The Messaging Service processes it and stores it in the database
4. The recipient's device gets a real-time update via WebSockets or Push Notifications

Receiving a Message
1. If the user is online, they receive the message instantly via WebSockets
2. If offline, a push notification is sent and the message is stored in the database
3. When the recipient reads the message, a read recipt is sent back

### 4. Choosing he right communication model

* WebSockets (RealTime Messaging)
* MQTT (IoT & Mobile Messaging)
* Server-Sent Events (Live updates, not bidirectional)
* Polling (REST API)

### 5. Message Storage & Database Choice

* Metadata Store (User Profiles, Contacts, Status, etc)
  * SQL 
* Message Storage (High Write throughput needed)
  * NoSQL (Cassandra, Dynamo DB) - Fast Writes, Scalable
  * Hybrid Approach (SQL for metadata + NoSQL for messages)

### 6. Message Ordering & Delivery Guarantees

* Challenges in Real-Time Messaging
  * Network delays -> Messages might arrive out of order
  * Duplicate messages if retries occur
  * Users might be offline, so messages must be queued
* Solutions
  * Use message queues for ordered, reliable message delivery
  * Assign monotonic timestamps at the server to enforce ordering
  * Use AKCs to conifrm delivery & prevent duplicates

### 7. Handling User Presence (Online/Offline Status)
1. WebSockets Heartbeat (Preferred)
  * Clients send a heartbeat ping every x seconds to indicate if they're online
  * If a client stops sending pings they're marked offline
2. Last Seen Timestamps (Fallback)
  * Store last activity timestamp in the database
  * Less real-time but useful for users who frequently disconnect

### 8. Push Notifications for Offline Users
* Firebase Cloud Messaging / Apple Push Notificaitons
* When a user is offline, system queues the message and triggers a push notification
* Message remains encrypted until the recipient retrieves it

### 9. Security & Encryption
* E2E Encryption
  * Messages should be encrypted on the sender's device and only decrypted by the recipient
  * Use Signal Protocol
  * Encryption keys should never be stored on the server
* Secure Authentication
  * OAuth 2.0 + JWT tokens for session management
  * Multi-Factor Authentication (MFA) for added security

### 10. Scaling the Messaging System
1. Horizontal Scaling
  * Scale WebSockets Servers using load balancer
  * Distribute messages across multiple databases to handle high traffic
2. Caching
  * Cache frequently accessed data (e.g. recent chats) using Redis
  * Reduce database reads for message retrieval
3. Geo-Replication
  * Store message data in multiple regions to reduce latency
  * Use CDN for media files