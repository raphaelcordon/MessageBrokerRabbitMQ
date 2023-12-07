# MessageBrokerRabbitMQ

## Table of Contents

- [Introduction](#introduction)
- [Application](#application)
- [Instructions](#instructions)

---

## **INTRODUCTION**

- .Net studying project to practice:
  - Broking Messages with RabbitMQ

---

## **APPLICATION**

 - Framework net7.0
 - Docker Container RabbitMQ
 - No Database

---

## **INSTRUCTIONS**

- This is a study project to be run locally only.
- Assuming Docker is installed and running:
  - run in CLI: "docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq"
  - RabbitMQ will be available at: http://localhost:15672/
  - User and Pass: guest
 
- Run first just the application: Producer.
  - In Swagger, execute the function User a few times.
    - ![image](https://github.com/raphaelcordon/MessageBrokerRabbitMQ/assets/56551789/720f894e-6d81-4658-8f24-eed3611844fa)
  - Check the RabbitMQ, in the tab "Queues and Streams" a new queue must be created and the column "Ready" will reflect the number of entries executed in the Swagger.
    - ![image](https://github.com/raphaelcordon/MessageBrokerRabbitMQ/assets/56551789/cbf27864-73f7-4002-ad08-eb9c601d6424)
  
- Then, Run the Consumer.
  - It is an application built to keep monitoring the Queue.
  - Check the RabbitMQ, the queue must be empty.

