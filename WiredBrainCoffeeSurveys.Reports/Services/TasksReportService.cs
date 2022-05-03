using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffeeSurveys.Reports.Services
{
    public static class TasksReportService
    {
        public static void GenerateTasksReport(SurveyResults results)
        {
            var tasks = new List<string>();

            double responseRate = results.NumberResponded / results.NumberSurveyed;
            double overallScore = (results.ServiceScore + results.CoffeeScore + results.FoodScore + results.PriceScore) / 4;

            if (results.CoffeeScore < results.FoodScore)
            {
                tasks.Add("Investigate coffee recipes and ingredients.");
            }

            // Change traditional if/else into a ternary statement
            tasks.Add(overallScore > 8.0 ? "Work with leadership to reward staff" : "Work with employees for improvement ideas.");

            // swap if else logic for switch statement using when keyword, more elegant but less readable than if else statement.
            tasks.Add(responseRate switch
            {
                var rate when rate < .33 => "Research options to improve response rate.",
                var rate when rate > .33 && rate < .66 => "Reward participants with free coffee coupon.",
                var rate when rate > .66 => "Reward participants with discount coffee coupon."
            });

            // Improved switch statement with fat arrow (lambda operator) syntax, finished of with underscore (discard operator) syntax
            tasks.Add(results.AreaToImprove switch
            {
                "RewardPrograms" => "Revisit the rewards deals.",
                "Cleanliness" => "Contact the cleaning vendor.",
                "MobileApp" => "Contact the consulting firm about the app.",
                _ => "Investigate individual comments for ideas."
            });

            Console.WriteLine(Environment.NewLine + "Tasks Output:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            File.WriteAllLines("TasksReport.csv", tasks);
        }
    }
}
