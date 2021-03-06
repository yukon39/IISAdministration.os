#Использовать asserts
#Использовать "utils"

#Область ОбработчикиТестов

&Тест
Процедура Тест_Количество() Экспорт
 	
	// Дано
	КонфигурацияХоста = ПомощникТестирования.КонфигурацияХоста();
	МенеджерСервера = Новый МенеджерСервераIIS(КонфигурацияХоста);
	Сайты = МенеджерСервера.Сайты;

	// Когда
	Количество = Сайты.Количество();

	// Тогда
	Ожидаем.Что(Количество).Равно(1);

КонецПроцедуры

&Тест
Процедура Тест_Первый() Экспорт
 	
	// Дано
	КонфигурацияХоста = ПомощникТестирования.КонфигурацияХоста();
	МенеджерСервера = Новый МенеджерСервераIIS(КонфигурацияХоста);
	Сайты = МенеджерСервера.Сайты;

	// Когда
	Сайт = Сайты.Первый();

	// Тогда
	Ожидаем.Что(Сайт).ИмеетТип("СайтIIS");
	Ожидаем.Что(Сайт.Идентификатор).Равно(1);

КонецПроцедуры

&Тест
Процедура Тест_ПолучитьПоИмени() Экспорт
 	
	// Дано
	КонфигурацияХоста = ПомощникТестирования.КонфигурацияХоста();
	МенеджерСервера = Новый МенеджерСервераIIS(КонфигурацияХоста);
	Сайты = МенеджерСервера.Сайты;
	ИмяСайта = "Default Web Site";

	// Когда
	Сайт = Сайты.Получить(ИмяСайта);

	// Тогда
	Ожидаем.Что(Сайт).ИмеетТип("СайтIIS");
	Ожидаем.Что(Сайт.Имя).Равно(ИмяСайта);

КонецПроцедуры

&Тест
Процедура Тест_ПолучитьПоИдентификатору() Экспорт
 	
	// Дано
	КонфигурацияХоста = ПомощникТестирования.КонфигурацияХоста();
	МенеджерСервера = Новый МенеджерСервераIIS(КонфигурацияХоста);
	Сайты = МенеджерСервера.Сайты;
	ИдентификаторСайта = 1;

	// Когда
	Сайт = Сайты.Получить(ИдентификаторСайта);

	// Тогда
	Ожидаем.Что(Сайт).ИмеетТип("СайтIIS");
	Ожидаем.Что(Сайт.Идентификатор).Равно(ИдентификаторСайта);

КонецПроцедуры

#КонецОбласти
