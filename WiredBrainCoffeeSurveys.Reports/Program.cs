using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
// Add JSON reader in above imports
using System.Text.Json;
using WiredBrainCoffeeSurveys.Reports.Services;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add boolean variable to allow a quit option for the user to quit the program
            bool quitApp = false;

            // Do While statement to allow the user to continue to read different report data in the same session until quit is typed
            do
            {
                Console.WriteLine("Please specify a report to run (rewards, comments, tasks, quit):");
                var selectedReport = Console.ReadLine();

                // Add second user choice to specify which set of JSON data to read
                Console.WriteLine("Please specify which quarter of data: (q1, q2)");
                var selectedFile = Console.ReadLine();

                // Add new variable to hold the C# compiled JSON data
                var surveyResults = SurveyDataService.GetSurveyDataByFileName(selectedFile);

                // Switch statement to allow the choices of the user to generate the corresponding report data
                switch (selectedReport)
                {
                    case "rewards":
                        // Add JSON variable as a paremter to the methods 
                        RewardsReportService.GenerateWinnerEmails(surveyResults);
                        break;
                    case "tasks":
                        TasksReportService.GenerateTasksReport(surveyResults);
                        break;
                    case "comments":
                        CommentsReportService.GenerateCommentsReport(surveyResults);
                        break;
                    case "quit":
                        quitApp = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, that's not a valid option.");
                        break;
                }

                Console.WriteLine();
            }

            while (!quitApp);
        }
    }
}
