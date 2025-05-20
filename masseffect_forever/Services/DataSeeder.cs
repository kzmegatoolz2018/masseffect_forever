using masseffect_forever.Data;
using masseffect_forever.Models;
using Microsoft.EntityFrameworkCore;

namespace masseffect_forever.Services
{
    public static class DataSeeder
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MassEffectContext>();
                
                
                context.Database.EnsureCreated();
                
                
                if (context.Characters.Any())
                {
                    return;
                }

                // Персонажи
                var characters = new List<Character>
                {
                    new Character 
                    { 
                        Id = 1, 
                        Name = "Шепард", 
                        Species = "Человек", 
                        Class = "Зависит от выбора игрока", 
                        Gender = "Зависит от выбора игрока", 
                        Affiliation = "Альянс Систем, Спектр", 
                        Status = "Зависит от концовки ME3", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 2, 
                        Name = "Гаррус Вакариан", 
                        Species = "Турианец", 
                        Class = "Страж", 
                        Gender = "Мужской", 
                        Affiliation = "C-СБ, Команда Шепарда", 
                        Status = "Жив (зависит от концовки ME3)", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 3, 
                        Name = "Лиара Т'Сони", 
                        Species = "Азари", 
                        Class = "Адепт", 
                        Gender = "Женский", 
                        Affiliation = "Серый Посредник, Команда Шепарда", 
                        Status = "Жива", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 4, 
                        Name = "Тали'Зора вас Нерайя", 
                        Species = "Кварианка", 
                        Class = "Инженер", 
                        Gender = "Женский", 
                        Affiliation = "Мигрирующий Флот, Команда Шепарда", 
                        Status = "Жива (зависит от концовки ME3)", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 5, 
                        Name = "Эшли Уильямс", 
                        Species = "Человек", 
                        Class = "Солдат", 
                        Gender = "Женский", 
                        Affiliation = "Альянс Систем, Спектр", 
                        Status = "Зависит от выборов игрока (ME1, ME3)", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 6, 
                        Name = "Кайден Аленко", 
                        Species = "Человек", 
                        Class = "Страж", 
                        Gender = "Мужской", 
                        Affiliation = "Альянс Систем, Спектр", 
                        Status = "Зависит от выборов игрока (ME1, ME3)", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 7, 
                        Name = "Урднот Рекс", 
                        Species = "Кроган", 
                        Class = "Баттл-мастер", 
                        Gender = "Мужской", 
                        Affiliation = "Клан Урднот, Команда Шепарда", 
                        Status = "Жив (зависит от выборов игрока в ME1)", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 8, 
                        Name = "СУЗИ", 
                        Species = "ИИ/Синтетик", 
                        Class = "Специалист", 
                        Gender = "Женский (по голосу)", 
                        Affiliation = "Цербер (изначально), Команда Шепарда", 
                        Status = "Активна (зависит от концовки ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 9, 
                        Name = "Легион", 
                        Species = "Гет", 
                        Class = "Инфильтратор", 
                        Gender = "Не применимо", 
                        Affiliation = "Геты, Команда Шепарда", 
                        Status = "Деактивирован (ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 10, 
                        Name = "Миранда Лоусон", 
                        Species = "Человек (генетически модифицированный)", 
                        Class = "Страж", 
                        Gender = "Женский", 
                        Affiliation = "Цербер (бывшая), Команда Шепарда", 
                        Status = "Жива (зависит от выборов игрока в ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 11, 
                        Name = "Призрак (Джек Харпер)", 
                        Species = "Человек (с имплантатами Жнецов)", 
                        Class = "Не применимо", 
                        Gender = "Мужской", 
                        Affiliation = "Цербер", 
                        Status = "Мёртв (ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 12, 
                        Name = "Мордин Солус", 
                        Species = "Саларианец", 
                        Class = "Инженер", 
                        Gender = "Мужской", 
                        Affiliation = "СОЗГ, Команда Шепарда", 
                        Status = "Мёртв (ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 13, 
                        Name = "Тейн Криос", 
                        Species = "Дрелл", 
                        Class = "Инфильтратор", 
                        Gender = "Мужской", 
                        Affiliation = "Команда Шепарда", 
                        Status = "Мёртв (ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 14, 
                        Name = "Джек (Подопытная Ноль)", 
                        Species = "Человек (биотик)", 
                        Class = "Адепт", 
                        Gender = "Женский", 
                        Affiliation = "Академия Гриссома, Команда Шепарда", 
                        Status = "Жива (зависит от выборов игрока в ME3)", 
                        FirstAppearance = new DateTime(2185, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    },
                    new Character 
                    { 
                        Id = 15, 
                        Name = "Джефф 'Джокер' Моро", 
                        Species = "Человек", 
                        Class = "Пилот", 
                        Gender = "Мужской", 
                        Affiliation = "Альянс Систем, Цербер (временно), Команда Шепарда", 
                        Status = "Жив (зависит от концовки ME3)", 
                        FirstAppearance = new DateTime(2183, 1, 1), 
                        LastAppearance = new DateTime(2186, 12, 31)
                    }
                };

                context.Characters.AddRange(characters);
                context.SaveChanges();

                // Биографии
                var biographies = new List<Biography>
                {
                    new Biography 
                    { 
                        Id = 1, 
                        CharacterId = 1, 
                        Birthplace = "Земля, космос или колония (зависит от предыстории)", 
                        Background = "Сирота с улиц, Колонист, Землянин, Герой войны, Уцелевший, Безжалостный", 
                        PsychologicalProfile = "Лидер, решительный, хладнокровный в бою, может быть Парагоном (Идеалистом) или Отступником (Прагматиком)", 
                        MilitaryHistory = "Награждён медалью Звезда Терры, первый человек-Спектр, герой битвы за Цитадель"
                    },
                    new Biography 
                    { 
                        Id = 2, 
                        CharacterId = 2, 
                        Birthplace = "Палавен", 
                        Background = "Бывший следователь C-СБ, снайпер", 
                        PsychologicalProfile = "Следует собственному моральному кодексу, предпочитает прямые действия, надежный друг, преданный", 
                        MilitaryHistory = "Служил в турианской армии, работал в С-СБ на Цитадели, руководил отрядом сопротивления на Омеге"
                    },
                    new Biography 
                    { 
                        Id = 3, 
                        CharacterId = 3, 
                        Birthplace = "Тессия", 
                        Background = "Дочь Матриарха Бенезии, археолог, эксперт по протеанам", 
                        PsychologicalProfile = "Интеллектуальная, целеустремленная, любознательная, эволюционировала от наивной учёной до безжалостного информационного брокера", 
                        MilitaryHistory = "Гражданский специалист, позже стала Серым Посредником, координатором разведданных для подготовки к войне со Жнецами"
                    },
                    new Biography 
                    { 
                        Id = 4, 
                        CharacterId = 4, 
                        Birthplace = "Мигрирующий Флот", 
                        Background = "Дочь адмирала Раэля'Зора, инженер", 
                        PsychologicalProfile = "Технически одаренная, лояльная своему народу, целеустремленная, прошла путь от юной паломницы до адмирала", 
                        MilitaryHistory = "Участвовала в паломничестве, связанном с исследованием гетов, стала адмиралом кварианского флота"
                    },
                    new Biography 
                    { 
                        Id = 5, 
                        CharacterId = 5, 
                        Birthplace = "Колония людей", 
                        Background = "Из военной семьи, третье поколение военных Альянса", 
                        PsychologicalProfile = "Прямолинейная, немного ксенофобная, но преданная своему долгу, религиозная", 
                        MilitaryHistory = "Служила в Альянсе, выжила при нападении гетов на Иден Прайм, возможно стала вторым человеком-Спектром"
                    },
                    new Biography 
                    { 
                        Id = 6, 
                        CharacterId = 6, 
                        Birthplace = "Земля, Ванкувер", 
                        Background = "Один из первых человеческих L2 биотиков", 
                        PsychologicalProfile = "Рассудительный, осторожный, страдает от мигреней из-за L2 имплантатов, придерживается правил", 
                        MilitaryHistory = "Участвовал в программе биотического обучения BAaT, служил в Альянсе, возможно стал вторым человеком-Спектром"
                    },
                    new Biography 
                    { 
                        Id = 7, 
                        CharacterId = 7, 
                        Birthplace = "Тучанка", 
                        Background = "Лидер клана Урднот, бывший наемник", 
                        PsychologicalProfile = "Жестокий воин с нетипичным для кроганов стратегическим мышлением, способен к дипломатии, когда это необходимо", 
                        MilitaryHistory = "Боевой мастер, сражался в Восстании Кроганов, работал наемником, стал лидером клана Урднот и объединителем кроганов"
                    },
                    new Biography 
                    { 
                        Id = 8, 
                        CharacterId = 8, 
                        Birthplace = "Создана Цербером", 
                        Background = "Искусственный интеллект, изначально для корабля 'Нормандия SR-2', позже получила физическое тело", 
                        PsychologicalProfile = "Эволюционировала от строгой подчиненной программы до самосознающего существа, проявляет любознательность, юмор и привязанность", 
                        MilitaryHistory = "Боевая поддержка экипажа 'Нормандии', тактический советник"
                    },
                    new Biography 
                    { 
                        Id = 9, 
                        CharacterId = 9, 
                        Birthplace = "Не применимо, платформа собрана гетами", 
                        Background = "Уникальная платформа гетов, содержащая 1183 программы", 
                        PsychologicalProfile = "Настроен на сотрудничество с органиками, стремится к пониманию создателей (кварианцев)", 
                        MilitaryHistory = "Собирал данные за пределами вуали Персея, следил за Шепардом, боролся против 'еретиков' среди гетов"
                    },
                    new Biography 
                    { 
                        Id = 10, 
                        CharacterId = 10, 
                        Birthplace = "Создана в лаборатории", 
                        Background = "Генетически спроектирована отцом-миллиардером Генри Лоусоном", 
                        PsychologicalProfile = "Перфекционистка, холодная на первый взгляд, но способна к глубоким привязанностям, особенно по отношению к сестре", 
                        MilitaryHistory = "Высокопоставленный оперативник Цербера, руководитель проекта 'Лазарь' по воскрешению Шепарда"
                    },
                    new Biography 
                    { 
                        Id = 11, 
                        CharacterId = 11, 
                        Birthplace = "Неизвестно", 
                        Background = "Бывший наемник Альянса, стал богатым бизнесменом, затем основал Цербер после Первого Контакта", 
                        PsychologicalProfile = "Манипулятор, верит в превосходство человечества, готов на любые средства для достижения цели", 
                        MilitaryHistory = "Основатель и руководитель террористической организации Цербер, координировал множество тайных операций"
                    },
                    new Biography 
                    { 
                        Id = 12, 
                        CharacterId = 12, 
                        Birthplace = "Суркеш (планета саларианцев)", 
                        Background = "Гениальный учёный, бывший оперативник ГОР", 
                        PsychologicalProfile = "Гиперактивный ум, говорит быстро, живет по принципу 'цель оправдывает средства', но в конце испытывает раскаяние", 
                        MilitaryHistory = "Работал на ГОР, участвовал в модификации генофага, позже попытался исправить свою ошибку"
                    },
                    new Biography 
                    { 
                        Id = 13, 
                        CharacterId = 13, 
                        Birthplace = "Кахье (родная планета дреллов)", 
                        Background = "Убийца, нанятый ханарами, отошел от дел из-за болезни", 
                        PsychologicalProfile = "Духовный, созерцательный, испытывает сожаление о прошлых поступках, предан семье", 
                        MilitaryHistory = "Профессиональный убийца, работавший на ханаров, специалист по скрытным операциям"
                    },
                    new Biography 
                    { 
                        Id = 14, 
                        CharacterId = 14, 
                        Birthplace = "Неизвестно", 
                        Background = "Похищена Цербером в детстве, подвергалась жестоким биотическим экспериментам", 
                        PsychologicalProfile = "Агрессивная, недоверчивая, психологически травмированная, но постепенно находит внутренний покой", 
                        MilitaryHistory = "Сбежала из тюрьмы, была пиратом, позже стала преподавателем в Академии Гриссома"
                    },
                    new Biography 
                    { 
                        Id = 15, 
                        CharacterId = 15, 
                        Birthplace = "Земные колонии", 
                        Background = "Страдает синдромом Вролика (хрупкость костей), лучший пилот Альянса", 
                        PsychologicalProfile = "Использует юмор как защитный механизм, самоуверенный, преданный корабля и команде", 
                        MilitaryHistory = "Элитный пилот Альянса Систем, дезертировал, чтобы помочь Шепарду против Коллекционеров"
                    }
                };

                context.Biographies.AddRange(biographies);
                context.SaveChanges();

                // Сюжетные флаги
                var plotFlags = new List<PlotFlag>
                {
                    new PlotFlag 
                    { 
                        Id = 1, 
                        Name = "Решение Совета", 
                        Game = "Mass Effect 1", 
                        Description = "Спасение или пожертвование Советом ради уничтожения Властелина", 
                        Impact = "Определяет состав Совета в ME2 и ME3, влияет на отношение рас Совета к человечеству", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 2, 
                        Name = "Вермайр: Эшли или Кайден", 
                        Game = "Mass Effect 1", 
                        Description = "Шепард должен выбрать, кого из членов команды спасти на Вермайре", 
                        Impact = "Определяет, кто из персонажей выживет и будет доступен в ME2 и ME3", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 3, 
                        Name = "Судьба Рекса", 
                        Game = "Mass Effect 1", 
                        Description = "Шепард может убить или успокоить Рекса на Вермайре", 
                        Impact = "Определяет, будет ли Рекс лидером кроганов в ME2 и ME3, влияет на стабильность кроганского союза", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 4, 
                        Name = "Рахни", 
                        Game = "Mass Effect 1", 
                        Description = "Уничтожение последней королевы рахни или её освобождение", 
                        Impact = "Влияет на присутствие рахни в ME3 и доступные военные ресурсы", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 5, 
                        Name = "База Коллекционеров", 
                        Game = "Mass Effect 2", 
                        Description = "Уничтожение базы или её сохранение для Цербера", 
                        Impact = "Влияет на отношения с Призраком, доступные ресурсы в войне и некоторые опции в ME3", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 6, 
                        Name = "Лояльность команды", 
                        Game = "Mass Effect 2", 
                        Description = "Выполнение персональных заданий каждого члена команды", 
                        Impact = "Определяет, кто выживет в самоубийственной миссии и взаимодействия в ME3", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 7, 
                        Name = "Легион и геты", 
                        Game = "Mass Effect 2, Mass Effect 3", 
                        Description = "Решения относительно гетов, включая перезапись 'еретиков'", 
                        Impact = "Влияет на силу гетов и возможность мира между гетами и кварианцами в ME3", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 8, 
                        Name = "Генофаг", 
                        Game = "Mass Effect 3", 
                        Description = "Лечение генофага или обман кроганов", 
                        Impact = "Определяет судьбу кроганской расы, влияет на поддержку от кроганов и саларианцев", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 9, 
                        Name = "Конфликт гетов и кварианцев", 
                        Game = "Mass Effect 3", 
                        Description = "Достижение мира между расами, поддержка одной из сторон или гибель обеих", 
                        Impact = "Определяет, какие расы выживут и будут доступны для финальной битвы", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 10, 
                        Name = "Финальный выбор", 
                        Game = "Mass Effect 3", 
                        Description = "Выбор между Уничтожением, Контролем, Синтезом или Отказом", 
                        Impact = "Определяет судьбу всей галактики, Шепарда и синтетической жизни", 
                        IsCritical = true 
                    },
                    new PlotFlag 
                    { 
                        Id = 11, 
                        Name = "Спасение Совета на Цитадели", 
                        Game = "Mass Effect 3", 
                        Description = "Успешное предотвращение переворота Цербера", 
                        Impact = "Влияет на состав Совета и политическую ситуацию в финальной битве", 
                        IsCritical = false 
                    },
                    new PlotFlag 
                    { 
                        Id = 12, 
                        Name = "Украденная память", 
                        Game = "Mass Effect 2", 
                        Description = "Помощь Касуми в миссии на Бекенштейне", 
                        Impact = "Определяет судьбу Касуми и устройства 'Серый ящик'", 
                        IsCritical = false 
                    },
                    new PlotFlag 
                    { 
                        Id = 13, 
                        Name = "Омега", 
                        Game = "Mass Effect 3", 
                        Description = "Помощь Арии Т'Лоак в восстановлении контроля над Омегой", 
                        Impact = "Влияет на доступные ресурсы и отношения с Арией", 
                        IsCritical = false 
                    },
                    new PlotFlag 
                    { 
                        Id = 14, 
                        Name = "Проект 'Повелитель'", 
                        Game = "Mass Effect 1", 
                        Description = "Уничтожение или сохранение последнего торианского создания", 
                        Impact = "Влияет на некоторые второстепенные задания в ME3", 
                        IsCritical = false 
                    },
                    new PlotFlag 
                    { 
                        Id = 15, 
                        Name = "Судьба Давида Арчера", 
                        Game = "Mass Effect 2", 
                        Description = "Решение о судьбе подопытного в проекте 'Властелин'", 
                        Impact = "Встреча с Давидом в Академии Гриссома в ME3", 
                        IsCritical = false 
                    }
                };

                context.PlotFlags.AddRange(plotFlags);
                context.SaveChanges();

                // Романтические интересы
                var romanticInterests = new List<RomanticInterest>
                {
                    new RomanticInterest 
                    { 
                        Id = 1, 
                        CharacterId = 2, 
                        AvailableFor = "Женский Шепард", 
                        Game = "Mass Effect 2, Mass Effect 3", 
                        CompatibleChoices = "Любая предыстория", 
                        RelationshipArc = "От боевого товарища до глубокой романтической привязанности", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 2, 
                        CharacterId = 3, 
                        AvailableFor = "Мужской и Женский Шепард", 
                        Game = "Mass Effect 1, Mass Effect 3", 
                        CompatibleChoices = "Любая предыстория", 
                        RelationshipArc = "Глубокая эмоциональная и интеллектуальная связь, может продолжаться через все игры", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 3, 
                        CharacterId = 4, 
                        AvailableFor = "Мужской Шепард", 
                        Game = "Mass Effect 2, Mass Effect 3", 
                        CompatibleChoices = "Необходима лояльность", 
                        RelationshipArc = "От дружбы до осторожного романтического знакомства из-за биологических различий", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 4, 
                        CharacterId = 5, 
                        AvailableFor = "Мужской Шепард", 
                        Game = "Mass Effect 1, Mass Effect 3", 
                        CompatibleChoices = "Необходимо спасти на Вермайре", 
                        RelationshipArc = "Сложные отношения после событий ME2, возможно восстановление в ME3", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 5, 
                        CharacterId = 6, 
                        AvailableFor = "Женский Шепард", 
                        Game = "Mass Effect 1, Mass Effect 3", 
                        CompatibleChoices = "Необходимо спасти на Вермайре", 
                        RelationshipArc = "Сложные отношения после событий ME2, возможно восстановление в ME3", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 6, 
                        CharacterId = 10, 
                        AvailableFor = "Мужской Шепард", 
                        Game = "Mass Effect 2, Mass Effect 3", 
                        CompatibleChoices = "Необходима лояльность", 
                        RelationshipArc = "От профессиональных отношений до личной привязанности", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 7, 
                        CharacterId = 13, 
                        AvailableFor = "Женский Шепард", 
                        Game = "Mass Effect 2", 
                        CompatibleChoices = "Необходима лояльность", 
                        RelationshipArc = "Духовная и философская связь, отягощенная его смертельной болезнью", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 8, 
                        CharacterId = 14, 
                        AvailableFor = "Мужской Шепард", 
                        Game = "Mass Effect 2, Mass Effect 3", 
                        CompatibleChoices = "Необходима лояльность", 
                        RelationshipArc = "От враждебности к доверию и привязанности", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 9, 
                        CharacterId = 15, 
                        AvailableFor = "Не доступен для Шепарда", 
                        Game = "Mass Effect 3", 
                        CompatibleChoices = "Не применимо", 
                        RelationshipArc = "Может развить романтические отношения с СУЗИ", 
                        IsExclusive = true 
                    },
                    new RomanticInterest 
                    { 
                        Id = 10, 
                        CharacterId = 8, 
                        AvailableFor = "Не доступен для Шепарда", 
                        Game = "Mass Effect 3", 
                        CompatibleChoices = "Не применимо", 
                        RelationshipArc = "Может развить романтические отношения с Джокером", 
                        IsExclusive = true 
                    }
                };

                context.RomanticInterests.AddRange(romanticInterests);
                context.SaveChanges();
            }
        }
    }
}
