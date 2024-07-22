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

Обрабатывает события от Писателя и Читателя, отправляя команды Читателю

## Взаимодействие микросервисов

1. Для изменения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет команду в микросервис Writer

2. Для чтения данных клиент отправляет запрос в микросервис Gateway, а тот отправляет запрос в микросервис Reader

3. После изменения данных микросервис Writer отправляет событие изменения данных в очередь

4. Микросервис Coordinator извлекает событие изменения данных из очереди и отправляет команду на изменение данных в микросервис Reader

5. Микросервис Reader обрабатывает команду на изменение данных и отправляет событие подтверждения выполнения команды в очередь

6. Микросервис Coordinator извлекает событие подтверждения выполнения команды из очереди и заботится о том, чтобы эта команда не выполнилась повторно

## Таблицы баз данных микросервисов Writer и Reader

1. AppEventType - Тип события приложения

	- Id, int, PK - Идентификатор

	- Name, nvarchar(400) (string) - Наименование

Данные:
```
[
	{ "Id": 1, "Name": "DummyItemMain.Insert" },
	{ "Id": 2, "Name": "DummyItemMain.Update" },
	{ "Id": 3, "Name": "DummyItemMain.Delete" }
]
```

2. AppEventStatus - Статус события приложения

	- Id, int, PK - Идентификатор

	- Name, string(50) (string) - Наименование

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

3. AppEventPayloadStatus - Статус полезной нагрузки события приложения

	- Id, int, PK - Идентификатор

	- Name, string(50) (string) - Наименование

Данные:
```
[
	{ "Id": 1, "Name": "Created" },
	{ "Id": 2, "Name": "Prepared" },
	{ "Id": 3, "Name": "Processed" }
]
```

4. AppEvent - Событие приложения

	- Id, bigint (long), PK, auto - Идентификатор

	- IsPublished, bit (bool), DF (false) - Признак опубликованности

	- Date, datetime - Дата

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- AppEventTypeId, int, FK (AppEventType) - Идентификатор действия события приложения

	- AppEventStatusId, int, FK (AppEventStatus) - Идентификатор статуса события приложения

5. AppEventPayload - Полезная нагрузка события приложения

	- Id, bigint (long), PK, auto - Идентификатор

	- IsPublished, bit (bool), DF (false) - Признак опубликованности

	- Date, datetime - Дата

	- AppEventId, bigint (long), FK (AppEvent) - Идентификатор записи события приложения

	- AppEventPayloadStatusId, int, FK (AppEventStatus) - Идентификатор статуса события приложения

	- Content, nvarchar(max) (string) - Содержимое

6. DummyItem - Фиктивный предмет (сущность)

	- Id, bigint (long), PK, auto - Идентификатор

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- Name, nvarchar(50) (string) - Имя

7. AppEventCommitForDummyItem - Фиксация события для фиктивного предмета

	- AppEventId, bigint (long), FK (AppEvent) - Идентификатор записи события приложения

	- Id, bigint (long) - Идентификатор

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- Name, nvarchar(50) (string), null - Имя

8. AppEventRollbackForDummyItem - Откат события для фиктивного предмета

	- AppEventId, bigint (long), FK (AppEvent) - Идентификатор записи события приложения

	- Id, bigint (long) - Идентификатор

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- Name, nvarchar(50) (string), null - Имя

9. DummyNode - Фиктивный узел (сущность)

	- Id, bigint (long), PK, auto - Идентификатор

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- Name, nvarchar(50) (string) - Имя

	- ParentId, bigint (long), FK (DummyNode), null - Идентификатор родителя

10. AppEventCommitForDummyNode - Фиксация события для фиктивного узла

	- AppEventId, bigint (long), FK (AppEvent) - Идентификатор записи события приложения

	- Id, bigint (long) - Идентификатор

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- Name, nvarchar(50) (string), null - Имя

	- ParentId, bigint (long), FK (DummyNode), null - Идентификатор родителя

11. AppEventRollbackForDummyNode - Откат события для фиктивного узла

	- AppEventId, bigint (long), FK (AppEvent) - Идентификатор записи события приложения

	- Id, bigint (long) - Идентификатор

	- CorrelationId, uniqueidentifier (GUID) - Идентификатор корелляции

	- Name, nvarchar(50) (string), null - Имя

	- ParentId, bigint (long), FK (DummyNode), null - Идентификатор родителя

## Обработка изменений в таблице сущности микросервиса Writer

1. Микросервис Writer проводит изменения в таблице сущности, сохраняет в таблице AppEvent соответствующее событие со статустом Created и значением false в поле IsPublished, в таблице AppEventPayload сохраняет его полезные нагрузки со статустом Created и значением false в поле IsPublished, а также создаёт записи в таблицах AppEventCommitFor и AppEventRollbackFor

2. Микросервис Writer извлекает из таблицы AppEvent самую раннюю запись со статусом Created и значением false в поле IsPublished, отправляет в очередь сообщение о создании события и устанавливает значение в поле IsPublished равным true

3. Микросервис Coordinator извлекает из очереди сообщение о создании события от микросервиса Writer, добавляет запись в таблицу WriterEvent со статусом Created и значением false в поле IsPublished в случае, если она там отсутствует

4. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Created и значением false в поле IsPublished, отправляет в очередь сообщение о начале сохранения события и устанавливает значение в поле IsPublished равным true

5. Микросервис Writer извлекает из очереди сообщение о начале сохранения события и для соответствующей записи в таблице AppEvent устанавливает значение поля AppEventStatusId равным Saving

6. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Created и значением в поле IsPublished равным true, затем запрашивает у микросервиса Writer полезные нагрузки события со статусом Created, соответствующего этой записи

7. Микросервис Writer в ответ на запрос полезных нагрузок извлекает из таблицы AppEventPayload первые 10 записей в статусе Created с AppEventId, указанном в запросе

8. Микросервис Coordinator после получения полезных нагрузок события сохраняет их в таблице WriterEventPayload в статусе Created и значением false в поле IsPublished

9. Микросервис Coordinator извлекает из таблицы WriterEventPayload самую раннюю запись со статусом Created и значением false в поле IsPublished, отправляет в очередь сообщение о сохранении полезной нагрузки события и устанавливает значение в поле IsPublished равным true

10. Микросервис Writer извлекает из очереди сообщение о сохранении полезной нагрузки события и для соответствующей записи в таблице AppEventPayload устанавливает значение поля AppEventPayloadStatusId равным Saved

11. Микросервис Coordinator повторяет шаги 6, 8, 9 до тех пор, пока запрос полезных нагрузок не вернёт пустой список, после чего устанавливает для соответствующей записи в таблице WriterEvent значение поля AppEventStatusId равным Saved и значением false в поле IsPublished

12. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Saved и значением false в поле IsPublished, затем отправляет в очередь сообщение о завершении сохранения события и устанавливает значение в поле IsPublished равным true

13. Микросервис Writer извлекает из очереди сообщение о завершении сохранения события и для соответствующей записи в таблице AppEvent устанавливает значение поля AppEventStatusId равным Saved, а значение в поле IsPublished равным false

14. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Saved и значением true в поле IsPublished, затем для этой записи устанавливает значение в поле WriterEventStatusId равным Activated, а в поле IsPublished равным false

15. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Activated и значением false в поле IsPublished, затем отправляет в очередь сообщение о подготовке события и устанавливает значение в поле IsPublished равным true

16. Микросервис Reader извлекает из очереди сообщение о подготовке события, сохраняет его в таблице AppEvent в статусе Created и значением false в поле IsPublished

17. Микросервис Reader извлекает из таблицы AppEvent самую раннюю запись со статусом Created и значением false в поле IsPublished, затем отправляет в очередь сообщение о начале подготовки события и устанавливает значение в поле IsPublished равным true

18. Микросервис Coordinator извлекает из очереди сообщение о начале подготовки события и для соответствующей записи в таблице WriterEvent устанавливает значение поля AppEventStatusId равным Preparing, а значение в поле IsPublished равным false

19. Микросервис Coordinator извлекает первые 10 записей из таблицы WriterEventPayload в статусе Created, связанные с самой ранней записью со статусом Preparing в таблице WriterEvent, и отправляет команду в микросервис Reader на подготовку полезных нагрузок события

20. Микросервис Reader в обработчике команды на подготовку полезных нагрузок события сохраняет их в таблице AppEventPayload в статусе Created и значением false в поле IsPublished

21. Микросервис Reader извлекает из таблицы AppEventPayload самую раннюю запись со статусом Created и значением false в поле IsPublished, затем отправляет в очередь сообщение о завершении подготовки полезной нагрузки события и устанавливает значение в поле IsPublished равным true

22. Микросервис Coordinator извлекает из очереди сообщение о завершении подготовки полезной нагрузки события и для соответствуюей записи в таблице WriterEventPayload устанавливает значение поля AppEventPayloadStatusId равным Prepared, а значение в поле IsPublished равным false

23. Микросервис Coordinator повторяет шаги 19 и 22 до тех пор, пока в таблице WriterEventPayload не останется полезных нагрузок в статусе Created и значением false в поле IsPublished, связанных с самой ранней записью со статусом Preparing в таблице WriterEvent, после чего устанавливает для соответствующей записи в таблице WriterEvent значение поля AppEventStatusId равным Prepared, а значение в поле IsPublished равным false

24. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Prepared и значением false в поле IsPublished, затем отправляет в очередь сообщение об обработке события и устанавливает значение в поле IsPublished равным true

25. Микросервис Reader извлекает из очереди сообщение об обработке события и для соответствующей записи в таблице AppEvent, устанавливает значение поля AppEventStatusId равным Processing, а значение в поле IsPublished равным false

26. Микросервис Reader извлекает из таблицы AppEvent самую раннюю запись со статусом Processing и значением false в поле IsPublished, затем отправляет в очередь сообщение о начале обработки события и устанавливает значение в поле IsPublished равным true

27. Микросервис Coordinator извлекает из очереди сообщение о начале обработки события и для соответствуюей записи в таблице WriterEvent устанавливает значение поля AppEventStatusId равным Processing, а значение в поле IsPublished равным false

28. Микросервис Reader по очереди извлекает записи из таблицы AppEventPayload в статусе Created и значением true в поле IsPublished, связанные с самой ранней записью со статусом Processing в таблице AppEvent, для каждой из них создаёт записи в таблицах AppEventCommitFor и AppEventRollbackFor, после чего для текущей записи из таблицы AppEventPayload устанавливает значение в поле AppEventPayloadStatusId равным Processed, а значение в поле IsPublished равным false

29. Микросервис Reader извлекает записи из таблицы AppEventPayload в статусе Processed и значением false в поле IsPublished, затем отправляет в очередь сообщение о завершении обработки полезной нагрузки события и устанавливает значение в поле IsPublished равным true

30. Микросервис Coordinator извлекает из очереди сообщение о завершении обработки полезной нагрузки события и для соответствуюей записи в таблице WriterEventPayload устанавливает значение поля AppEventPayloadStatusId равным Processed, а значение в поле IsPublished равным false

31. Микросервис Reader повторяет шаги 28 и 29 до тех пор, пока не останется связанных с обрабатываемым событием полезных нагрузок, после чего для текущей записи из таблицы AppEvent устанавливает значение в поле AppEventStatusId равным Processed, а значение в поле IsPublished равным false

32. Микросервис Reader извлекает записи из таблицы AppEvent в статусе Processed и значением false в поле IsPublished, затем отправляет в очередь сообщение о завершении обработки события и устанавливает значение в поле IsPublished равным true

33. Микросервис Coordinator извлекает из очереди сообщение о завершении обработки события и для соответствуюей записи в таблице WriterEvent устанавливает значение поля AppEventStatusId равным Processed, а значение в поле IsPublished равным false

34. COMMIT

34. 1. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Processed и значением false в поле IsPublished, затем устанавливает значение в поле WriterEventStatusId равным Committing, а значение в поле IsPublished равным false

34. 2. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Committing и значением false в поле IsPublished, затем отправляет в очередь сообщение о начале подтверждения события и устанавливает значение в поле IsPublished равным true

34. 3. Микросервис Reader извлекает из очереди сообщение о начале подтверждения события, изменяет таблицу сущности в соответствии с записями в таблице AppEventCommitFor для данного события, устанавливает для соответствующей записи в таблице AppEvent значение в поле AppEventStatusId равным Committed, а значение в поле IsPublished равным false

34. 4. Микросервис Reader извлекает из таблицы AppEvent самую раннюю запись со статусом Committed и значением false в поле IsPublished, затем отправляет в очередь сообщение о завершении подтверждения события и устанавливает значение в поле IsPublished равным true

34. 5. Микросервис Coordinator извлекает из очереди сообщение о завершении подтверждения события, для соответствуюей записи в таблице WriterEvent устанавливает значение поля AppEventStatusId равным Committed, а значение в поле IsPublished равным false

34. 6. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Committed и значением false в поле IsPublished, затем отправляет в очередь сообщение о подтверждении события и устанавливает значение в поле IsPublished равным true

34. 7. Микросервис Writer извлекает из очереди сообщение о подтверждении события и для соответствующей записи в таблице AppEvent устанавливает значение поля AppEventStatusId равным Committed, а значение в поле IsPublished равным false

35. ROLLBACK

35. 1. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Processed и значением false в поле IsPublished, затем устанавливает значение в поле WriterEventStatusId равным Canceling, а значение в поле IsPublished равным false

35. 2. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Canceling и значением false в поле IsPublished, затем отправляет в очередь сообщение о начале отмены события и устанавливает значение в поле IsPublished равным true

35. 3. Микросервис Reader извлекает из очереди сообщение о начале отмены события, изменяет таблицу сущности в соответствии с записями в таблице AppEventRollbackFor для данного события, устанавливает для соответствующей записи в таблице AppEvent значение в поле AppEventStatusId равным Canceled, а значение в поле IsPublished равным false

35. 4. Микросервис Reader извлекает из таблицы AppEvent самую раннюю запись со статусом Canceled и значением false в поле IsPublished, затем отправляет в очередь сообщение о завершении отмены события и устанавливает значение в поле IsPublished равным true

35. 5. Микросервис Coordinator извлекает из очереди сообщение о завершении отмены события, для соответствуюей записи в таблице WriterEvent устанавливает значение поля AppEventStatusId равным Canceled, а значение в поле IsPublished равным false

35. 6. Микросервис Coordinator извлекает из таблицы WriterEvent самую раннюю запись со статусом Canceled и значением false в поле IsPublished, затем отправляет в очередь сообщение об отмене события и устанавливает значение в поле IsPublished равным true

35. 7. Микросервис Writer извлекает из очереди сообщение об отмене события, изменяет таблицу сущности в соответствии с записями в таблице AppEventRollbackFor для данного события и для соответствующей записи в таблице AppEvent устанавливает значение поля AppEventStatusId равным Canceled, а значение в поле IsPublished равным false
