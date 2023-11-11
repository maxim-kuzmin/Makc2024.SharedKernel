# Tasking

## Назначение

Приложение предназначено для выполнения и отмены результатов выполнения задач различных типов.

Каждый тип задачи содержит свой набор входных параметров.

Набор действий для выполнения задачи и её отмены сохраняется и при необходимости может быть запущен повторно.

## Архитектура

Архитектура приложения - микросервисная.

Взаимодействие микросервисов друг с другом осуществляется асинхронно с использованием паттерна Transactional Outbox.

Транзакции организуются с использованием паттерна Saga.

Для реализации паттернов Transactional Outbox и Saga используется библиотека MassTransit.

Для асинхронной передачи данных между микросервисами используется брокер сообщений RabbitMQ.

Чтение и модификация реляционных данных происходит с использованием паттерна CQRS.

Для модификации реляционных данных используется библиотека EntityFramework.

Для чтения реляционных данных используется библиотека Dapper.

Для хранения реляционных данных используется SQL база данных PostgreSQL.

Для хранения нереляционных данных используется NoSQL база данных MongoDb.

Приложение разворачивается в докере.

### Докер-контейнеры приложения

1. frontend-web - Фронт Web на React

2. backend-gateway-webapi - Шлюз Web API для взаимодействия с фронтом Web

3. backend-service-task-executor - Выполнение задач

4. backend-service-task-reader - Чтение задач ("Q" в паттерне CQRS)

5. backend-service-task-storage - Хранение задач ("С" в паттерне CQRS)

6. backend-feature-task-management - Организация работы сервисов выполнения, чтения и хранения задач (через саги MassTransit)

### Докер-контейнеры внешних приложений

1. external-mongo - Сервер NoSQL базы данных MongoDb

2. external-mongo-express - Клиент NoSQL базы данных MongoDb

3. external-nginx - Прокси-сервер Nginx

4. external-postgres - Сервер SQL базы данных PostgreSQL

5. external-pgadmin - Клиент SQL базы данных PostgreSQL

6. external-pgbouncer - Программа Pgbouncer для управлений пулом соединений PostgreSQL

7. external-rabbitmq - Брокер сообщений RabbitMQ

## Certificate

1. Generates a self-signed certificate to enable HTTPS use in development:

```
dotnet dev-certs https -ep .\https\cert.pfx -p Makc2024
```

2. Trusts the certificate on the local machine:

```
dotnet dev-certs https --trust
```

3. Installs openssl:

```
winget install openssl
```

4. Creates the .crt file:

```
openssl pkcs12 -in .\https\cert.pfx -clcerts -nokeys -out .\https\cert.crt
```

5. Creates the .rsa file:

```
openssl pkcs12 -in .\https\cert.pfx -nocerts -nodes -out .\https\cert.rsa
```

## Docker

1. Start

```
docker-compose  -f ".\src\docker-compose.yml" -f ".\src\docker-compose.override.yml" --project-name="makc2024_tasking" up -d
```

2. Stop

```
docker-compose  -f ".\src\docker-compose.yml" -f ".\src\docker-compose.override.yml" --project-name="makc2024_tasking" down
```

## Help

1. Docker:

- https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-7.0

- https://habr.com/ru/companies/microsoft/articles/435914/

2. OpenSSL:

- https://think.unblog.ch/en/how-to-install-openssl-on-windows-10-11/
