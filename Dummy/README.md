# Coordination

## Миграции

cd .\src\Backend\src\Writer\src\Infrastructure

dotnet ef migrations add InitialCreate --startup-project ../Apps/WebApp --output-dir ./App/Db/Migrations

## Микросервисы

1. Gateway - Шлюз

Напраляет запросы и команды от клиентов другим микросервисам

2. Writer - Писатель

Изменяет сущности (добавляет, обновляет, удаляет)

3. Reader - Читатель

Читает сущности

4. Coordinator - Координатор

Координирует события

## Взаимодействие микросервисов

1. Для изменения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет команду в микросервис Writer

2. Для чтения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет запрос в микросервис Reader

3. После изменения данных микросервис Writer отправляет событие изменения данных в очередь

4. Микросервис Coordinator извлекает из очереди сообщение о событии изменения данных и сообщения об окончании обработки события от других микросервисов, а затем отправляет в очередь сообщение о фиксации или откате события

5. Микросервис Reader извлекает из очереди сообщение о событии изменения данных, обрабатывает его, отправляет в очередь сообщение об окончании обработки события, извлекает из очереди сообщение о фиксации или откате события, обрабатывает фиксацию или откат

## Таблицы для хранения событий приложения в базах данных всех микросервисов

1. AppEventStatus - Статус события приложения

	- Id, int, PK - Идентификатор

	- Name, string(255) (string) - Наименование

Данные:
```
[	
	{ "Id": 1, "Name": "Created" },
	{ "Id": 2, "Name": "Saving" },
	{ "Id": 3, "Name": "Saved" },
	{ "Id": 5, "Name": "Activated" },
	{ "Id": 6, "Name": "Preparing" },
	{ "Id": 7, "Name": "Prepared" },
	{ "Id": 8, "Name": "Committing" },
	{ "Id": 9, "Name": "Committed" },
	{ "Id": 10, "Name": "Canceling" },
	{ "Id": 11, "Name": "Canceled" }
]
```

2. AppEventPayloadAction - Действие полезной нагрузки события приложения

	- Id, int, PK - Идентификатор

	- Name, string(255) (string) - Наименование

Данные:
```
[	
	{ "Id": 1, "Name": "Insert" },
	{ "Id": 2, "Name": "Update" },
	{ "Id": 3, "Name": "Delete" }
]
```

3. AppEventPayloadStatus - Статус полезной нагрузки события приложения

	- Id, int, PK - Идентификатор

	- Name, string(255) (string) - Наименование

Данные:
```
[
	{ "Id": 1, "Name": "Created" },
	{ "Id": 2, "Name": "Prepared" },
	{ "Id": 3, "Name": "Processed" }
]
```

4. AppEventSource - Источник события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- Name, nvarchar(255) (string) - Наименование

Данные:
```
[
	{ "Id": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "Writer" },
	{ "Id": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "Reader" },
	{ "Id": 'CA6F8D1C-5CBC-4702-981B-18CC64E10C97', "Name": "Coordinator" }
]
```

5. AppEventSourceEntity - Сущность источника события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- SourceId, uniqueidentifier (GUID), FK (AppEventSource) - Идентификатор источника

	- Name, nvarchar(255) (string) - Наименование

Данные:
```
[
	{ "Id": '999C9463-C223-4FC6-9F98-979CA4F1A704', "AppEventSourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem" },
	{ "Id": '52EDF994-3579-4251-A31C-C5D03DBCDF8E', "AppEventSourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyNode" },
	{ "Id": '80F1FAA8-DC7D-415D-823C-8A805DDCC90E', "AppEventSourceId": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "DummyItem" },
	{ "Id": '9C271241-A451-4629-843B-B45B5B33ED50', "AppEventSourceId": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "DummyNode" }
]
```

6. AppEventSourceAction - Действие источника события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- SourceId, uniqueidentifier (GUID), FK (AppEventSource) - Идентификатор источника

	- Name, nvarchar(255) (string) - Наименование

Данные:
```
[
	{ "Id": 'DEE17A73-91DD-4CC7-87E7-D799F4CCB212', "AppEventSourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem.Insert" },
	{ "Id": 'F8CB5AE6-1876-4172-BCF4-D75C1E5C3349', "AppEventSourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem.Update" },
	{ "Id": 'DF833540-A5D3-4710-9C32-DCE1762EF7B7', "AppEventSourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem.Delete" }
]
```

7. AppEvent - Событие приложения

	- Id, uniqueidentifier (GUID), PK, auto - Идентификатор

	- SourceActionId, int, FK (AppEventSourceAction) - Идентификатор действия источника	

	- StatusId, int, FK (AppEventStatus) - Идентификатор статуса

	- IsPublished, bit (bool), DF (false) - Признак опубликованности

	- Date, datetime - Дата

8. AppEventPayloadFieldType - Тип поля полезной нагрузки приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- Name, nvarchar(255) (string) - Наименование

Данные:
```
[
	{ "Id": 'D8367A8C-C48B-483C-A22B-C76CBFC46751', "Name": "Boolean" },
	{ "Id": '366BD717-3AAF-4827-A3C6-4A6240E73BAE', "Name": "DateTime" },
	{ "Id": '6167C569-E104-4B92-BB8E-37B0AAAC7FAE', "Name": "Decimal" },
	{ "Id": '66B3B999-30BF-445A-8C02-5FA2E57ADB2D', "Name": "GUID" },	
	{ "Id": '51FF3E01-A1D0-4592-BDAD-81E10184B97D', "Name": "Int32" },
	{ "Id": '0BB9259D-C1C2-4ABD-BFBB-C07A7D6180BD', "Name": "Int64" },	
	{ "Id": '22B0E478-A277-4D86-9300-43D3F2277278', "Name": "String" }
]
```

9. AppEventPayload - Полезная нагрузка события приложения

	- Id, bigint (long), PK, auto - Идентификатор

	- EventId, bigint (long), FK (AppEvent) - Идентификатор события

	- PayloadActionId, int, FK (AppEventPayloadAction) - Идентификатор действия полезной нагрузки

	- PayloadStatusId, int, FK (AppEventPayloadStatus) - Идентификатор статуса полезной нагрузки

	- SourceEntityId, uniqueidentifier (GUID), FK (AppEventSourceEntity) - Идентификатор сущности источника

	- KeyFieldTypeId, uniqueidentifier (GUID), FK (AppEventPayloadFieldType) - Идентификатор типа поля ключа

	- Key, nvarchar(50) (string) - Ключ

	- IsPublished, bit (bool), DF (false) - Признак опубликованности

10. AppEventPayloadField - Поле полезной нагрузки события приложения

	- Id, bigint (long), PK, auto - Идентификатор	
	
	- PayloadId, bigint (long), FK (AppEventPayload) - Идентификатор полезной нагрузки

	- TypeId, uniqueidentifier (GUID), FK (AppEventPayloadFieldType) - Идентификатор типа

	- Name, nvarchar(255) (string) - Наименование

	- NewValue, nvarchar(max) (string) - Новое значение

	- OldValue, nvarchar(max) (string) - Старое значение

## Таблицы для хранения сущностей в базах данных микросервисов Writer и Reader

1. DummyItem - Фиктивный предмет (сущность)

	- Id, bigint (long), PK, auto - Идентификатор

	- Name, nvarchar(255) (string) - Имя

2. DummyNode - Фиктивный узел (сущность)

	- Id, bigint (long), PK, auto - Идентификатор

	- Name, nvarchar(255) (string) - Имя

	- ParentId, bigint (long), FK (DummyNode), null - Идентификатор родителя

## Обработка изменений в таблице сущности микросервиса Writer

1. Микросервис Writer проводит изменения в таблице сущности, сохраняет в таблице AppEvent соответствующее событие со статустом Created и значением false в поле IsPublished, в таблице AppEventPayload сохраняет его полезные нагрузки со статустом Created и значением false в поле IsPublished, а также создаёт записи в таблице AppEventPayloadField

2. Микросервис Writer извлекает из таблицы AppEvent самую раннюю запись со статусом Created и значением false в поле IsPublished, отправляет в очередь сообщение о создании события и устанавливает значение в поле IsPublished равным true

3. Микросервис Coordinator извлекает из очереди сообщение о создании события от микросервиса Writer, добавляет запись в таблицу AppEvent со статусом Created и значением false в поле IsPublished в случае, если она там отсутствует
