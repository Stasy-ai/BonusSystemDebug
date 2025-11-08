using System;
using System.Collections.Generic;

namespace BonusSystemDebug
{
	class Program
	{
		static void Main(string[] args)
		{
			var calculator = new BonusCalculator();

			// Тестовые случаи
			RunTest(calculator, "Иван", 5, 8, "developer", true, 10);       // Ожидается: 19375
			RunTest(calculator, "Зинаида", 2, 3, "manager", false, 5);      // Ожидается: 8250
			RunTest(calculator, "Геннадий", 0, 1, "intern", false, 0);      // Ожидается: 500
			RunTest(calculator, "Акакий", 10, 10, "director", false, 0);    // Ожидается: 45000
			RunTest(calculator, "Богдан", 1, 0, "developer", false, 2);     // Ожидается: 2000
			RunTest(calculator, "Кукуцаполь", 8, 12, "teamlead", true, 15); // Ожидается: 47500
			RunTest(calculator, "Ибрагим", -1, -123, "intern", false, -89); // Ожидается: ошибка валидации
			RunTest(calculator, "Алефтина", 20, 30, "director", true, 40);  // Ожидается: 50000 (максимум)

			Console.WriteLine($"\nОбработано сотрудников: {calculator.GetProcessedCount()}");
		}

		static void RunTest(BonusCalculator calculator, string name, int exp, int projects,
						  string position, bool achievements, int overtime)
		{
			Console.WriteLine($"\nДанные: {name}, опыт {exp} лет, проекты {projects}, должность {position}, достижения {achievements}, сверхурочные {overtime}ч");

			bool isValid = calculator.ValidateInput(name, exp, projects, overtime);
			Console.WriteLine($"Валидация: {(isValid ? "ПРОЙДЕНА" : "ОШИБКА")}");

			if (isValid)
			{
				double bonus = calculator.CalculateBonus(name, exp, projects, position, achievements, overtime);
				string report = calculator.GenerateReport(name, bonus);
				Console.WriteLine(report);
			}
			else
			{
				Console.WriteLine("Расчет не выполнен: невалидные входные данные");
			}
		}
	}
}