#Использовать asserts
#Использовать "utils"

#Область ОбработчикиТестов

&Тест
Процедура Тест_Переименовать() Экспорт
 	
	// Дано
	КонфигурацияХоста = ПомощникТестирования.КонфигурацияХоста();
	МенеджерСервера = Новый МенеджерСервераIIS(КонфигурацияХоста);
	ПулыПриложений = МенеджерСервера.ПулыПриложений;
	ПулПриложений = ПулыПриложений["EnterpriseAppPool"];
	ИмяПулаПриложений = "TestApplicationPool";

	// Когда
	ПулПриложений.Переименовать(ИмяПулаПриложений);

	// Тогда
	Ожидаем.Что(ПулПриложений.Имя).Равно(ИмяПулаПриложений);

КонецПроцедуры

#КонецОбласти
