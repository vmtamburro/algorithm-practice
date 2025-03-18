# Distributed File Storage System
*Like Google Drive, S3, Dropbox*

### 1. Understanding the Problem Statement
* Upload, Store, and retrieve files
* Support large file sizes (GBs to TBs)
* Ensure high durability (no data loss)
* Handle concurrent file acess
* Provide metadata (file size, ownership, permissions)
* Design a scalable, fault-tolerant, highly available distributed file storage system

### 2. High-Level Architecture
Major Components
1. Client Interface (API/GUI) - Users interact with the system via REST APIs or a web UI
2. Load Balancer - Distributes requests across multiple servers
3. Metadata Service (DB) - Stores file metadata (name, size, owner, location)
4. Chunking & Storage Service - Splits large files into smaller chunks and stores them across multiple nodes
5. Replication & Fault Tolerance - Ensures data durability by replicating chunks across nodes
6. Consistency & Coordination - Uses consensus protocols to maintain consistency
7. Indexing & Search - Allows users to find files quickly

### 3. File Storage Process
1. File Upload
  * User Uploads a file
  * Chunks are stored across multiple storage node with replication
  * Metadata Service tracks file location, permissions, and version

2. File Retrieval
  * User requesta a file -> Metadata service identifies chunk locations -> Client Retrieves chunks -> Reassembles File

3. File Deletion
  * Metadata is marked for deletion -> Background job deletes chunks -> Space is freed up

### 4. Key Design Considerations
1. Chunking Strategy
  * Large files are split into fixed-size chunks 
  * Benefits:
    * Parallel Uploads/Downloads -> Speeds up file access
    * Efficient Storage -> Only modified chunks need to be updated
    * Fault Tolerance -> If one chunk fails, othr chunks are still accessible

2. Metadata Storage
  * Store file names, locations, owner, permissions, timestamps, version history
  * SQL - for strong consistency
  * NoSQL for scalability
  * Distributed KV Store

3. Replciation Strategy (Ensuring Data Durability)
  * Replciation Factor = 3
  * Primary-Backup Model (One primary Copy, two backups)
  * Erasure Coding - reduces storage overhead compared to full replciation

### 5. Scaling the System
1. Horizontal Scaling (Adding More Machines)
  * Use Distributed Hash Table (DHT) to distribute chunks efficiently
  * Store file chunks in multiple data centers (geo-redundancy)
  * Sharding metadata service across multiple database nodes
2. Caching Strategy
  * Cache Hot files in Redis or CDN
3. Handling Concurrent Access
  * Lock-free mechanisms for read-heavy workload
  * Versioning to handle simultaneous file updates

### 6. Tech Stack
* Client API - REST
* Load Balancer - NGINX
* Metadata Store - SQL
* Storage Nodes - Amazon S3, Blob
* Replication - Paxos, Raft
* Caching - Redis
* Search Index - Elastic Search

### API Design

File Upload

```txt
POST /upload  
Body: { "filename": "photo.jpg", "user_id": "123", "file_data": "binary_data" }  
Response: { "file_id": "xyz123", "status": "success" }
```

File Download

```
GET /download?file_id=xyz123  
Response: { "file_data": "binary_data", "status": "success" }

```

Metadata

```
GET /metadata?file_id=xyz123  
Response: { "filename": "photo.jpg", "size": "5MB", "created_at": "2025-03-15" }
```