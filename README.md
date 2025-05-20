# Mass Effect API

## Описание проекта

Mass Effect API - это REST API,  предоставляющее доступ к данным вселенной популярной игровой серии Mass Effect.

## Технологии

- .NET Core 8
- Entity Framework Core (In-Memory Database)
- Swagger для документации API
- Архитектура REST

## Структура проекта

Проект организован в соответствии с принципами чистой архитектуры и имеет следующую структуру:

```
masseffect_forever/
├── Controllers/        # Контроллеры API для обработки HTTP-запросов
├── Data/               # Контекст и конфигурация базы данных
├── DTO/                # Data Transfer Objects для API-ответов
├── Models/             # Доменные модели сущностей
└── Services/           # Сервисы для бизнес-логики
```

## Модели данных

### Character (Персонаж)
Представляет персонажей вселенной Mass Effect:
- Id - уникальный идентификатор
- Name - имя персонажа
- Species - раса персонажа (человек, азари, турианец и т.д.)
- Class - класс персонажа (солдат, адепт, инженер и т.д.)
- Gender - пол персонажа
- Affiliation - принадлежность к организациям
- Status - текущий статус (жив, мёртв, зависит от выбора игрока)
- FirstAppearance - первое появление в серии
- LastAppearance - последнее появление в серии

### Biography (Биография)
Подробная информация о происхождении и истории персонажа:
- Id - уникальный идентификатор
- CharacterId - связь с персонажем
- Birthplace - место рождения
- Background - предыстория
- PsychologicalProfile - психологический профиль
- MilitaryHistory - военная история

### PlotFlag (Флаг сюжета)
Ключевые события и решения, влияющие на сюжет игры:
- Id - уникальный идентификатор
- Name - название события/решения
- Game - игра, в которой появляется данный сюжетный выбор
- Description - описание выбора
- Impact - влияние на дальнейший сюжет
- IsCritical - является ли выбор критически важным для сюжета

### RomanticInterest (Романтический интерес)
Романтические отношения между персонажами:
- Id - уникальный идентификатор
- CharacterId - связь с персонажем
- AvailableFor - для кого доступен (мужской/женский Шепард)
- Game - игра, в которой доступны отношения
- CompatibleChoices - совместимые выборы для отношений
- RelationshipArc - описание развития отношений
- IsExclusive - являются ли отношения эксклюзивными

## API Endpoints

### Characters
- GET /api/characters - получить список всех персонажей
- GET /api/characters?filter=Шепард&sort=name - получить отфильтрованный и отсортированный список персонажей
- GET /api/characters/{id} - получить персонажа по Id
- POST /api/characters - создать нового персонажа
- PUT /api/characters/{id} - обновить персонажа
- DELETE /api/characters/{id} - удалить персонажа

### PlotFlags
- GET /api/plotflags - получить список всех сюжетных флагов
- GET /api/plotflags?filter=Генофаг&sort=game - получить отфильтрованный и отсортированный список флагов
- GET /api/plotflags/{id} - получить сюжетный флаг по Id
- POST /api/plotflags - создать новый сюжетный флаг
- PUT /api/plotflags/{id} - обновить сюжетный флаг
- DELETE /api/plotflags/{id} - удалить сюжетный флаг

### RomanticInterests
- GET /api/romanticinterests - получить список всех романтических интересов
- GET /api/romanticinterests?filter=Женский&sort=game - получить отфильтрованный и отсортированный список
- GET /api/romanticinterests/{id} - получить романтический интерес по Id
- POST /api/romanticinterests - создать новый романтический интерес
- PUT /api/romanticinterests/{id} - обновить романтический интерес
- DELETE /api/romanticinterests/{id} - удалить романтический интерес

### Biographies
- GET /api/biographies - получить список всех биографий
- GET /api/biographies?filter=Палавен&sort=characterId - получить отфильтрованный и отсортированный список
- GET /api/biographies/{id} - получить биографию по Id
- POST /api/biographies - создать новую биографию
- PUT /api/biographies/{id} - обновить биографию
- DELETE /api/biographies/{id} - удалить биографию

## Фильтрация и сортировка

API поддерживает динамическую фильтрацию и сортировку для всех эндпоинтов:

- **filter** - строка для фильтрации результатов (ищет совпадения в текстовых полях)
- **sort** - поле для сортировки результатов (можно указать любое поле модели)

Пример: `GET /api/characters?filter=турианец&sort=name`

## Инициализация данных

При запуске приложения база данных автоматически заполняется большим набором данных из вселенной Mass Effect:
- 15 персонажей (Шепард, Гаррус, Лиара, Тали и др.)
- Подробные биографии для каждого персонажа
- 15 ключевых сюжетных флагов (важные решения игрока из трилогии)
- 10 романтических интересов для различных персонажей

## Запуск проекта

Для запуска проекта выполните следующие шаги:

1. Убедитесь, что у вас установлен .NET 8 SDK
2. Клонируйте репозиторий
3. Откройте решение в Visual Studio или другой IDE
4. Запустите проект

После запуска API будет доступен по адресу: `https://localhost:5001` или `http://localhost:5000`
Документация Swagger будет доступна по адресу: `https://localhost:5001/swagger`

## Полезные ссылки

- [.NET Core 8 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [Mass Effect Wiki](https://masseffect.fandom.com/wiki/Mass_Effect_Wiki) - источник данных для API
