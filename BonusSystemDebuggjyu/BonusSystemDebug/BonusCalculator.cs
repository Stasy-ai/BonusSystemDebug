using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusSystemDebug
{
	public class BonusCalculator
	{
		private List<string> processedEmployees = new List<string>();

		public double CalculateBonus(string employeeName, int experience, int completedProjects,
								   string position, bool hasAchievements, int overtimeHours)
		{
			// БАГ 1
			if (experience < 0) experience = 0;
			if (completedProjects < 0) completedProjects = 0;
			if (overtimeHours < 0) overtimeHours = 0;

			double baseBonus = experience * 1000;

			double projectsBonus = completedProjects * 500;

			
			double positionMultiplier = GetPositionMultiplier(position);
			double totalBonus = baseBonus + projectsBonus;
			totalBonus = totalBonus * positionMultiplier;

			double achievementsBonus = 0;
			if (hasAchievements)
			{
				achievementsBonus = totalBonus * 0.25;
			}

			double overtimeBonus = CalculateOvertimeBonus(overtimeHours);
			totalBonus += achievementsBonus + overtimeBonus;

			if (totalBonus < 0)
			{
				totalBonus = 0;
			}

			if (totalBonus >= 50000)
			{
				totalBonus = 50000;
			}

			// БАГ 7
			if (!string.IsNullOrEmpty(employeeName))
			{
				processedEmployees.Add(employeeName);
			}

			return totalBonus;
		}

		private double GetPositionMultiplier(string position)
		{
			if (string.IsNullOrEmpty(position))
				return 1.0;

			switch (position.ToLower())
			{
				case "intern":
					return 1.0;
				case "developer":
					return 1.5;  // Исправлено с 1.2 на 1.5
				case "manager":
					return 2.0;
				case "teamlead":
					return 2.5;  // Исправлено с 2.0 на 2.5
				case "director":
					return 3.0;
				default:
					return 1.0;
			}
		}

		private double CalculateOvertimeBonus(int overtimeHours)
		{
			return overtimeHours * 250;
		}

		public bool ValidateInput(string employeeName, int experience, int completedProjects,
								int overtimeHours)
		{
			if (!string.IsNullOrEmpty(employeeName) && experience >= 0 && completedProjects >= 0 && overtimeHours >= 0)
			{
				return true;
			}
			return false;
		}

		public string GenerateReport(string employeeName, double bonus)
		{
			return $"Сотрудник: {employeeName}, Бонус: {bonus} Rub";
		}

		public int GetProcessedCount()
		{
			return processedEmployees.Count;
		}

		public void ClearProcessedList()
		{
			processedEmployees.Clear();
		}
	}
}