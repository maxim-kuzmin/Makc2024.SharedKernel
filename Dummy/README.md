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

Координирует распределённые транзакции через отправку в очередь сообщений о фиксации или откате транзакций

## Взаимодействие микросервисов

1. Для изменения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет команду в микросервис Writer

2. Для чтения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет запрос в микросервис Reader

3. После изменения данных микросервис Writer отправляет событие изменения данных в очередь

4. Микросервис Coordinator извлекает из очереди сообщения о событиях, запускает транзакции и отправляет в очередь сообщения об их фиксации или откате

5. Микросервис Reader извлекает из очереди сообщение о событии изменения данных, обрабатывает его, создаёт событие об окончании обработки события изменения данных, отправляет в очередь сообщение об этом событии, извлекает из очереди сообщение о фиксации или откате события изменения данных, обрабатывает фиксацию или откат

## Таблицы для хранения сущностей обработки событий приложения в базах данных всех микросервисов

1. AppEventSource - Источник события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- Name, nvarchar(255) (String) - Наименование

Данные:
```
[
	{ "Id": 'CA6F8D1C-5CBC-4702-981B-18CC64E10C97', "Name": "Coordinator" },
	{ "Id": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "Reader" },
	{ "Id": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "Writer" }
]
```

2. AppEventEntity - Сущность события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- SourceId, uniqueidentifier (GUID), FK (AppEventSource) - Идентификатор источника

	- Name, nvarchar(255) (String) - Наименование

Данные:
```
[
	//
	// Coordinator
	//
	{ "Id": '9F0624BF-B58B-453C-BA49-6FD06E855B19', "SourceId": 'CA6F8D1C-5CBC-4702-981B-18CC64E10C97', "Name": "AppEvent" },
	//
	// Reader
	//
	{ "Id": '60FA2297-2B6E-4A50-BFB9-32E548FA750A', "SourceId": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "AppEvent" },
	{ "Id": '80F1FAA8-DC7D-415D-823C-8A805DDCC90E', "SourceId": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "DummyItem" },
	{ "Id": '9C271241-A451-4629-843B-B45B5B33ED50', "SourceId": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "DummyNode" },
	//
	// Writer
	//
	{ "Id": '789808F0-50DE-48AE-8042-6B74EB5D6E2E', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "AppEvent" },
	{ "Id": '999C9463-C223-4FC6-9F98-979CA4F1A704', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem" },
	{ "Id": '52EDF994-3579-4251-A31C-C5D03DBCDF8E', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyNode" },
]
```

3. AppEventAction - Действие события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- SourceId, uniqueidentifier (GUID), FK (AppEventSource) - Идентификатор источника

	- Name, nvarchar(255) (String) - Наименование

Данные:
```
[
	//
	// Coordinator
	//
	{ "Id": 'D49167EC-C466-42E8-9917-3919EC6D66CB', "SourceId": 'CA6F8D1C-5CBC-4702-981B-18CC64E10C97', "Name": "AppEvent.Commit" },
	{ "Id": '5D38192C-D57C-4FEA-B58F-9B78431867EE', "SourceId": 'CA6F8D1C-5CBC-4702-981B-18CC64E10C97', "Name": "AppEvent.Rollback" },
	//
	// Reader
	//
	{ "Id": '7416779F-4C23-4AED-8BBC-4696430B7E27', "SourceId": '4F6F6D39-681B-4DD8-8173-4530761F1CA8', "Name": "AppEvent.Insert" },
	//
	// Writer
	//
	{ "Id": '826BDF74-DF3F-4854-B302-CF9759176922', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "AppEvent.Insert" },
	{ "Id": 'DEE17A73-91DD-4CC7-87E7-D799F4CCB212', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem.Insert" },
	{ "Id": 'F8CB5AE6-1876-4172-BCF4-D75C1E5C3349', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem.Update" },
	{ "Id": 'DF833540-A5D3-4710-9C32-DCE1762EF7B7', "SourceId": '2D8B30CD-57DA-40B3-B694-2470C6BF8D95', "Name": "DummyItem.Delete" },
]
```

4. AppEventDataType - Тип данных события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- Name, nvarchar(255) (String) - Наименование

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

5. AppEvent - Событие приложения

	- Id, uniqueidentifier (GUID), PK, auto - Идентификатор

	- ActionId, uniqueidentifier (GUID), FK (AppEventAction) - Идентификатор действия

	- Date, datetime (DateTime) - Дата
	
	- PayloadCount, int (Int32) - Счётчик полезных нагрузок

	- IsProcessed, bit (Boolean), DF (false) - Признак обработанности

6. AppEventPayload - Полезная нагрузка события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор

	- EventId, uniqueidentifier (GUID), FK (AppEvent) - Идентификатор события

	- EntityId, uniqueidentifier (GUID), FK (AppEventEntity) - Идентификатор сущности
	
	- IsProcessed, bit (Boolean), DF (false) - Признак обработанности

7. AppEventPayloadField - Поле полезной нагрузки события приложения

	- Id, uniqueidentifier (GUID), PK - Идентификатор
	
	- PayloadId, uniqueidentifier (GUID), FK (AppEventPayload) - Идентификатор полезной нагрузки

	- DataTypeId, uniqueidentifier (GUID), FK (AppEventDataType) - Идентификатор типа данных

	- Name, nvarchar(255) (String) - Наименование

	- Value, nvarchar(max) (String) - Значение

	- PrevValue, nvarchar(max) (String) - Предыдущее значение
	
	- PrevValueEventId, uniqueidentifier (GUID), null - Идентификатор события предыдущего значения

	- IsProcessed, bit (Boolean), DF (false) - Признак обработанности

## Таблицы для хранения сущностей предметной области в базах данных микросервисов Writer и Reader

1. DummyItem - Фиктивный предмет (сущность)

	- Id, bigint (Int64), PK, auto - Идентификатор

	- Name, nvarchar(255) (String) - Имя

2. DummyNode - Фиктивный узел (сущность)

	- Id, bigint (Int64), PK, auto - Идентификатор

	- Name, nvarchar(255) (String) - Имя

	- ParentId, bigint (Int64), FK (DummyNode), null - Идентификатор родителя

## Обработка изменений в таблице сущности предметной области микросервиса Writer

1. Микросервис Writer:

- В таблицу сущности предметной области вносит изменения.

- В таблицу AppEvent вставляет соответствующее событие со значением false в поле IsProcessed.

- В таблицу AppEventPayload вставляет его полезные нагрузки со значением true в поле IsProcessed.

- В таблицу AppEventPayloadField вставляет поля полезных нагрузок со значением true в поле IsProcessed.

2. Микросервис Writer:

- Из таблицы AppEvent извлекает событие со значением false в поле IsProcessed.

- В очередь отправляет сообщение о возникновении этого события.

- Зтому событию устанавливает значение в поле IsProcessed равным true.

3. Микросервис Reader:

- Из очереди извлекает сообщение о возникновении события в микросервисе Writer.

- В таблицу AppEvent вставляет это событие со значением false в поле IsProcessed.

4. Микросервис Reader:

- Из таблицы AppEvent извлекает событие со значением false в поле IsProcessed, минимальным значением в поле Date и количеством записей в таблице AppEventPayload меньшим, чем значение в поле PayloadCount этого события.

- У микросервиса Writer запрашивает порцию полезных нагрузок этого события.

- В таблицу AppEventPayload вставляет полученные полезные нагрузки со значением false в поле IsProcessed.

- В таблицу AppEventPayloadField вставляет поля полученных полезных нагрузок со значением true в поле IsProcessed, если значение в поле PrevValueEventId равно null или в таблице AppEvent есть событие со значением true в поле IsProcessed и значением в поле Id равным значению в поле PrevValueEventId, в противном случае значение в поле IsProcessed вставляемых в таблицу AppEventPayloadField записей должно быть равно false.

- У микросервиса Writer запрашивает очередную порцию полезных нагрузок этого события и делает с ними описанное выше до тех пор, пока общее количество загруженных полезных нагрузок события не сравняется со значением в его поле PayloadCount.

- В случае, если все записи в таблице AppEventPayloadField, имеющие отношение к загруженным полезным нагрузкам, содержат true в поле IsProcessed, для всех соответствующих им записей в таблице AppEventPayload значение в поле IsProcessed также устанавливаетеся в true.

- В случае, если все записи в таблице AppEventPayloadField, имеющие отношение к загруженным полезным нагрузкам, содержат true в поле IsProcessed, для всех соответствующих им записей в таблице AppEventPayload значение в поле IsProcessed также устанавливаетеся в true.

5. Микросервис Reader:

 - Из таблицы AppEvent извлекает событие со значением false в поле IsProcessed, минимальным значением в поле Date и количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением false в поле IsProcessed хотя бы одной из этих записей.

- Из таблицы AppEventPayloadField извлекает порциями поля полезных нагрузок этого события со значением false в поле IsProcessed.

- Если в таблице AppEvent есть событие со значением true в поле IsProcessed и значением в поле Id равным значению в поле PrevValueEventId записей из таблицы AppEventPayloadField, извлечённых на предыдущем шаге, для этих записей значение в поле IsProcessed устанавливается равным true.

- Из таблицы AppEventPayload извлекает порциями полезные нагрузки этого события со значением false в поле IsProcessed.

- В случае, если все записи в таблице AppEventPayloadField, имеющие отношение к извлечённым на предыдущем шаге записям, содержат true в поле IsProcessed, для всех этих записей значение в поле IsProcessed также устанавливаетеся в true.

6. Микросервис Reader:

- Из таблицы AppEvent извлекает событие со значением false в поле IsProcessed, минимальным значением в поле Date, количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением true в поле IsProcessed всех этих записей.

- Этому событию устанавливает значение в поле IsProcessed равным true.

- В таблицу AppEvent вставляет собственное событие об окончании обработки чужого события со значением false в поле IsProcessed.

 7. Микросервис Reader:

- Из таблицы AppEvent извлекает собственное событие со значением false в поле IsProcessed.

- В очередь отправляет сообщение о возникновении этого события.

- Этому событию устанавливает значение в поле IsProcessed равным true.

8. Микросервис Coordinator:

- Из очереди извлекает сообщение о возникновении события в микросервисе Reader.

- В таблицу AppEvent вставляет это событие со значением false в поле IsProcessed.

9. Микросервис Coordinator:

- Действует аналогично микросервису Reader на шаге 4.

10. Микросервис Coordinator:

- Действует аналогично микросервису Reader на шаге 5.

11. Микросервис Coordinator:

- Из таблицы AppEvent извлекает событие со значением false в поле IsProcessed, минимальным значением в поле Date, количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением true в поле IsProcessed всех этих записей.

- Этому событию устанавливает значение в поле IsProcessed равным true.

- Извлекает из полезной нагрузки этого события идентификатор события микросервиса Writer.

- В таблицу AppEvent вставляет в случае его отсутствия собственное событие о запуске транзакции события микросервиса Writer со значением false в поле IsProcessed и значением равным числу микросервисов, которые обрабатывают это событие микросервиса Writer, в поле PayloadCount (в данном случае это значение будет равно 1, так как это событие микросервиса Writer обрабатывает только микросервис Reader).

- В таблицу AppEventPayload вставляет полезную нагрузку этого события со значением true в поле IsProcessed.

- В таблицу AppEventPayloadField вставляет поле полезной нагрузки этого события, соответствующее идентификатору события микросервиса Reader, со значением true в поле IsProcessed.

12. 1. Микросервис Coordinator (COMMIT):

- Из таблицы AppEvent извлекает собственное событие о запуске транзакции со значением false в поле IsProcessed, минимальным значением в поле Date, количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением true в поле IsProcessed всех этих записей.

- В очередь отправляет сообщение о фиксации транзакции этого события.

- Этому событию устанавливает значение в поле IsProcessed равным true.

12. 1. 1. Микросервис Reader:

- Из очереди извлекает сообщение о фиксации транзакции события.

- В таблицу AppEvent вставляет это событие со значением false в поле IsProcessed.

12. 1. 2. Микросервис Reader:

- Действует аналогично микросервису Reader на шаге 4.

12. 1. 3. Микросервис Reader:

- Действует аналогично микросервису Reader на шаге 5.

12. 1. 4. Микросервис Reader:

- Из таблицы AppEvent извлекает событие о фиксации транзакции события со значением false в поле IsProcessed, минимальным значением в поле Date, количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением true в поле IsProcessed всех этих записей.

- Этому событию устанавливает значение в поле IsProcessed равным true.

- Проводит необходимые изменения в таблицах сущностей, заменяя значения полей соответствующими значениями поля Value таблицы AppEventPayloadField.

12. 2. Микросервис Coordinator (ROLLBACK):

- Из таблицы AppEvent извлекает собственное событие о запуске транзакции со значением false в поле IsProcessed, минимальным значением в поле Date, отстающего от текущей даты на установленный в настройках интервал времени, количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением false в поле IsProcessed всех этих записей.

- В очередь отправляет сообщение об откате транзакции этого события.

- Этому событию устанавливает значение в поле IsProcessed равным true.

12. 2. 1. Микросервис Writer:

- Из очереди извлекает сообщение об откате транзакции события.

- В таблицу AppEvent вставляет это событие со значением false в поле IsProcessed.

12. 2. 2. Микросервис Writer:

- Действует аналогично микросервису Reader на шаге 4.

12. 2. 3. Микросервис Writer:

- Действует аналогично микросервису Reader на шаге 5.

12. 2. 4. Микросервис Reader:

- Из таблицы AppEvent извлекает событие об откате транзакции события со значением false в поле IsProcessed, минимальным значением в поле Date, количеством записей в таблице AppEventPayload равным значению в поле PayloadCount этого события и со значением true в поле IsProcessed всех этих записей.

- Этому событию устанавливает значение в поле IsProcessed равным true.

- Проводит необходимые изменения в таблицах сущностей, заменяя значения полей соответствующими значениями поля PrevValue таблицы AppEventPayloadField.
