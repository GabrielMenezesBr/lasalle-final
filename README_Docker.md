## **Docker Commands**

[Return to README](README.md)

### 1. **docker run** – Run a Container  
Runs a container from an image (downloads the image if not available locally).  
```bash
docker run -d -p 80:80 --name my-container nginx
```
- `-d`: Run in detached mode (in the background).  
- `-p 80:80`: Map port 80 on the host to port 80 in the container.  
- `--name`: Assigns a name to the container.

---

### 2. **docker ps** – List Running Containers  
Displays the currently running containers.
```bash
docker ps
```
- `-a`: List **all containers**, including stopped ones.

---

### 3. **docker images** – List Images  
Lists all Docker images available locally.
```bash
docker images
```

---

### 4. **docker pull** – Download an Image  
Pulls a Docker image from **Docker Hub** or another registry.
```bash
docker pull nginx
```

---

### 5. **docker exec** – Execute Commands in a Running Container  
Runs commands inside a running container.
```bash
docker exec -it my-container bash
```
- `-it`: Interactive mode (useful for running a shell).

---

### 6. **docker stop / start** – Stop or Start Containers  
Stops or starts a container by name or ID.
```bash
docker stop my-container
docker start my-container
```

---

### 7. **docker rm** – Remove Containers  
Removes one or more stopped containers.
```bash
docker rm my-container
```
- `-f`: Force-remove a running container.

---

### 8. **docker rmi** – Remove Images  
Deletes Docker images by name or ID.
```bash
docker rmi nginx
```
- `-f`: Force-remove an image.

---

### 9. **docker build** – Build an Image from a Dockerfile  
Creates a Docker image from a **Dockerfile**.
```bash
docker build -t my-image:latest .
```
- `-t`: Tags the image with a name and tag.

---

### 10. **docker logs** – View Container Logs  
Shows logs from a running or stopped container.
```bash
docker logs my-container
```
- `-f`: Follows logs in real time (like `tail -f`).

---

### 11. **docker network** – Manage Networks  
- **List networks**:
  ```bash
  docker network ls
  ```
- **Create a new network**:
  ```bash
  docker network create my-network
  ```
- **Attach a container to a network**:
  ```bash
  docker network connect my-network my-container
  ```

---

### 12. **docker volume** – Manage Volumes  
- **List volumes**:
  ```bash
  docker volume ls
  ```
- **Create a new volume**:
  ```bash
  docker volume create my-volume
  ```
- **Remove a volume**:
  ```bash
  docker volume rm my-volume
  ```

---

## **Docker Compose Commands**

### 1. **docker-compose up** – Start Services  
Starts and creates containers as defined in the `docker-compose.yml` file.
```bash
docker-compose up
```
- `-d`: Run in detached mode (background).  
- `--build`: Force a rebuild of the images.

---

### 2. **docker-compose down** – Stop and Remove Containers  
Stops and removes all containers and networks created by Docker Compose.
```bash
docker-compose down
```
- `-v`: Also removes volumes created by the services.

---

### 3. **docker-compose ps** – List Running Services  
Displays the status of all running services defined in the Compose file.
```bash
docker-compose ps
```

---

### 4. **docker-compose build** – Build Images  
Builds images for the services in the `docker-compose.yml` file.
```bash
docker-compose build
```
- `--no-cache`: Build without using cache.

---

### 5. **docker-compose logs** – View Service Logs  
Shows logs for the services defined in the Compose file.
```bash
docker-compose logs
```
- `-f`: Follow logs in real time.

---

### 6. **docker-compose stop / start** – Stop or Start Services  
Stops or starts the services defined in the Compose file.
```bash
docker-compose stop
docker-compose start
```

---

### 7. **docker-compose exec** – Execute Commands in a Service  
Runs a command inside a specific service container.
```bash
docker-compose exec web bash
```

---

### 8. **docker-compose restart** – Restart Services  
Restarts all services defined in the Compose file.
```bash
docker-compose restart
```

---

### 9. **docker-compose pull** – Pull Service Images  
Pulls the latest images for the services defined in the Compose file.
```bash
docker-compose pull
```

---

### 10. **docker-compose rm** – Remove Stopped Services  
Removes stopped containers created by Docker Compose.
```bash
docker-compose rm
```
- `-f`: Force removal without confirmation.
