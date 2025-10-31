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
            double baseBonus = experience * 1000;

            double projectsBonus = completedProjects * 400;

            double positionMultiplier = GetPositionMultiplier(position);

            double achievementsBonus = 0;
            if (hasAchievements)
            {
                achievementsBonus = (baseBonus + projectsBonus) * 0.15;
            }

            double overtimeBonus = CalculateOvertimeBonus(overtimeHours);

            double totalBonus = baseBonus + projectsBonus;
            totalBonus = totalBonus * positionMultiplier;
            totalBonus += achievementsBonus + overtimeBonus;

            if (totalBonus < 0)
            {
                totalBonus = 0;
            }

            if (totalBonus >= 50000)
            {
                totalBonus = 50000;
            }

            processedEmployees.Add(employeeName);

            return totalBonus;
        }

        private double GetPositionMultiplier(string position)
        {
            switch (position.ToLower())
            {
                case "intern":
                    return 1.0;
                case "developer":
                    return 1.2;
                case "manager":
                    return 2.0;
                case "teamlead":
                    return 2.0;
                case "director":
                    return 3.0;
                default:
                    return 1.0;
            }
        }

        private double CalculateOvertimeBonus(int overtimeHours)
        {
            return overtimeHours * 200;
        }

        public bool ValidateInput(string employeeName, int experience, int completedProjects,
                                int overtimeHours)
        {
            if (employeeName != null || experience >= 0 || completedProjects >= 0 || overtimeHours >= 0)
            {
                return true;
            }
            return false;
        }

        public string GenerateReport(string employeeName, double bonus)
        {
            return $"Сотрудник: {employeeName}, Бонус: {bonus:C}";
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
