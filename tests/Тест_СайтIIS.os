#Использовать asserts
#Использовать "utils"

#Область ОбработчикиТестов

&Тест
Процедура Тест_Первый() Экспорт
 	
	// Дано
	КонфигурацияХоста = ПомощникТестирования.КонфигурацияХоста();
	МенеджерСервера = Новый МенеджерСервераIIS(КонфигурацияХоста);
	Сайты = МенеджерСервера.Сайты;

	// Когда
	Сайт = Сайты.Первый();

	// Тогда
	Ожидаем.Что(Сайт.Идентификатор).Равно(1);
	Ожидаем.Что(Сайт.Имя).Равно("Default Web Site");

КонецПроцедуры

#КонецОбласти
