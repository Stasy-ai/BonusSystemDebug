using System;
using System.Collections.Generic;

namespace BonusSystemDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new BonusCalculator();

            RunTest(calculator, "Петр", -1, -5, "developer", true, -10);

            Console.WriteLine($"\nОбработано сотрудников: {calculator.GetProcessedCount()}");
        }

        static void RunTest(BonusCalculator calculator, string name, int exp, int projects,
                          string position, bool achievements, int overtime)
        {
            Console.WriteLine($"Данные: {name}, опыт {exp} лет, проекты {projects}, должность {position}, достижения {achievements}, сверхурочные {overtime}ч");

            bool isValid = calculator.ValidateInput(name, exp, projects, overtime);
            Console.WriteLine($"Валидация: {(isValid ? "ПРОЙДЕНА" : "ОШИБКА")}");

            if (isValid)
            {
                double bonus = calculator.CalculateBonus(name, exp, projects, position, achievements, overtime);
                string report = calculator.GenerateReport(name, bonus);
                Console.WriteLine(report);
            }
        }
    }
}