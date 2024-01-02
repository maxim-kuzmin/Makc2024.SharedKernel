# makc2024_tasking

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

1. frontend-web-reactvite - Фронт Web на React Vite

2. backend-gateway-web - Шлюз Web API для взаимодействия с фронтом Web

3. backend-task-executor-web - Выполнение задач

4. backend-task-reader-web - Чтение задач ("Q" в паттерне CQRS)

5. backend-task-storage-web - Хранение задач ("С" в паттерне CQRS)

6. backend-task-manager-web - Организация работы сервисов выполнения, чтения и хранения задач (через саги MassTransit)

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
dotnet dev-certs https -ep .\https\cert.pfx -p makc2024
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
docker-compose  -f ".\docker-compose.yml" -f ".\docker-compose.override.yml" --project-name="makc2024_tasking" up -d
```

2. Stop

```
docker-compose  -f ".\docker-compose.yml" -f ".\docker-compose.override.yml" --project-name="makc2024_tasking" down
```

## Help

1. Docker:

- https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-7.0

- https://habr.com/ru/companies/microsoft/articles/435914/

2. OpenSSL:

- https://think.unblog.ch/en/how-to-install-openssl-on-windows-10-11/

# Services

## TaskStorage

### Language

- **LanguageId** - string, PK, values:
    - **ru**
    - **en**

### ParameterType

- **ParameterTypeId** - string, PK,values:
    - **number**
    - **string**
    - **boolean**

### ParameterTypeResource

- **LanguageId** - string, PK, FK

- **ParameterTypeId** - string, PK, FK

- **ParameterTypeName** - string

- **ParameterTypeDescription** - string, null

### TaskStatus

- **TaskStatusId** - string, PK, values:
    - **open**
    - **in_progress**
    - **paused**
    - **done**

### TaskStatusResource

- **LanguageId** - string, PK, FK

- **TaskStatusId** - string, PK, FK

- **TaskStatusName** - string

- **TaskStatusDescription** - string, null

### TaskKind

- **TaskKindId** - string, PK, values:
    - **first_kind_task**
    - **second_kind_task**
    - **third_kind_task**

### TaskKindResource

- **LanguageId** - string, PK, FK

- **TaskKindId** - string, PK, FK

- **TaskKindName** - string

- **TaskKindDescription** - string, null

### TaskKindParameter

- **TaskKindId** - string, PK, FK

- **ParameterKey** - string, PK

- **ParameterTypeId** - string, FK

- **IsRequired** - bool

- **IsArray** - bool

- **Value** - string, null

### TaskKindParameterResource

- **LanguageId** - string, PK, FK

- **TaskKindId** - string, PK, FK

- **ParameterKey** - string, PK, FK

- **TaskKindParameterName** - string

- **TaskKindParameterDescription** - string, null

### Task

- **TaskId** - int, PK, auto generated values

- **TaskKindId** - string, FK

- **TaskStatusId** - string, FK

- **CommandToExecute** - string, null

- **CommandToRollback** - string, null

### TaskResource

- **LanguageId** - string, PK, FK

- **TaskId** - int, PK, FK

- **TaskTitle** - string

- **TaskDescription** - string, null

### TaskParameter

- **TaskId** - int, PK, FK

- **TaskKindId** - string, PK, FK

- **ParameterKey** - string, PK, FK

- **Value** - string, null

### TaskExecutionStatus

- **TaskExecutionStatusId** - string, PK, values:
    - **success**
    - **error**
    - **pending**
    - **in_progress**
    - **canceled**

### TaskExecutionStatusResource

- **LanguageId** - string, PK

- **TaskExecutionStatusId** - string, PK

- **TaskExecutionStatusName** - string

- **TaskExecutionStatusDescription** - string, null

### TaskExecution

- **TaskExecutionId** - string, PK, outside generated values

- **TaskId** - int, FK

- **TaskExecutionStatusId** - string, FK

- **IsRollback** - bool

- **CreationDate** - datetime

- **StartDate** - datetime

- **CompletionDate** - datetime

## TaskManager

### Action

- **ActionId** - string, PK, values:
    - **task_delete**
    - **task_insert**
    - **task_update**

### Transaction

- **TransactionId** - int, PK, auto generated values

- **ItitiatorId** - int

- **StartDate** - datetime

- **ActionId** - string, FK

- **Input** - string, null

- **TaskStorageState** - string, null

- **TaskStorageActionDate** - datetime, null

- **TaskReaderState** - string, null

- **TaskReaderActionDate** - datetime, null

# Action processing

## task_delete

### Input

- **InitiatorId** = 1

- **TaskId** = 1

### 1. Select state from TaskStorage

Task_from_TaskStorage_with_TaskId_1

### 2. Select state from TaskReader

Task_from_TaskReader_with_TaskId_1

### 3. Insert into Transaction

#### Input

- **InitiatorId** = 1

- **StartDate** = now()

- **Input** = { "TaskId": "1" }

- **TaskStorageState** = { Task_from_TaskStorage_with_TaskId_1 }

- **TaskStorageActionDate** = null

- **TaskReaderState** = { Task_from_TaskReader_with_TaskId_1 }

- **TaskReaderActionDate** = null

#### Output

- **TransactionId** = 1

### 4. Delete Task from TaskStorage

### 5. Update Transaction after TaskStorage action completed

#### Where

- **TransactionId** = 1

#### Input

- **TaskStorageActionDate** = now()

### 6. Delete Task from TaskReader

### 7. Update Transaction after TaskReader action completed

#### Where

- **TransactionId** = 1

#### Input

- **TaskReaderActionDate** = now()

### 8. Delete Transaction

#### Where

- **TransactionId** = 1

