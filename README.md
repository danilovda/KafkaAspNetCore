## Project Overview

**KafkaAspNetCore** is an example of integrating **ASP.NET Core Web API** with Apache **Kafka** for message streaming between microservices. The project demonstrates basic patterns for working with Kafka, including sending and receiving messages (Producer and Consumer) via a Web API. It also utilizes **Docker** for containerization and orchestration of services like Kafka, Zookeeper, and the ASP.NET Core application.

## Project Structure

The project consists of two main components:

- **Producer** — sends messages to Kafka (topic: `test-topic`).
- **Consumer** — receives messages from Kafka in real time using a background service.

## Technologies Used

- **ASP.NET Core** — Web framework for building APIs.
- **Apache Kafka** — Distributed stream-processing platform.
- **Confluent.Kafka** — .NET client for Kafka.
- **Docker and Docker Compose** — For containerization and managing services (Kafka, Zookeeper, ASP.NET Core).

## How to Run the Project

### With Docker

1. Make sure you have **Docker** installed.
2. Build and run the containers using Docker Compose:

   ```bash
   docker-compose up --build
   ```

3. The Web APIs will be accessible at [https://localhost:5101](https://localhost:5101) and [https://localhost:5201](https://localhost:5201).

### Usage Examples

- **Send a message to Kafka**:

  Send a POST request with a message body to the following endpoint:

  ```http
  POST https://localhost:5201/send
  Body: { "message": "Your Message" }
  ```

- **Receive messages from Kafka**:

  Messages will be displayed in the console when the Consumer service is running.

## Docker Compose

The `docker-compose.yml` file defines four services:

- **Zookeeper** — Coordinates and manages Kafka brokers.
- **Kafka** — Message broker for handling streams of messages.
- **KafkaProducerApi** — Web API application interacting with Kafka as a producer.
- **KafkaConsumerApi** — Web API application interacting with Kafka as a consumer.

