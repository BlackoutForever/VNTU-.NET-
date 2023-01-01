using Blackout.TaskPlanner.DataAccess;
using Blackout.TaskPlanner.DataAccess.Abstraction;
using Blackout.TaskPlanner.Domain.Logic;
using Blackout.TaskPlanner.Domain.Models;

namespace Blackout.TaskPlanner.ConsoleRunner
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WorkItem[] workItems;
            
            FileWorkItemRepository fileWorkItemRepository = new();
            SimpleTaskPlanner stp = new(fileWorkItemRepository);

            while (true)
            {
                PrintMenu();

                Console.Write("Choose the option: ");
                string? userChoice = Console.ReadLine();

                if (userChoice == "A" || userChoice == "a")
                {

                    WorkItem newWorkItem = new WorkItem(false);

                    fileWorkItemRepository.Add(newWorkItem);

                }

                else if (userChoice == "B" || userChoice == "b")
                {

                    workItems = stp.CreatePlan();
                    Console.WriteLine("The plan has been created:");
                    WorkItem.PrintWorkItems(workItems);

                }

                else if (userChoice == "M" || userChoice == "m")
                {

                    var tempWorkItems = fileWorkItemRepository.GetAll();

                    WorkItem.PrintWorkItems(tempWorkItems);

                    Console.Write(@"Choose the number of the task to mark as complited\uncomplited: ");

                    int itemNumberToMark = int.Parse(Console.ReadLine());

                    tempWorkItems[itemNumberToMark - 1].IsCompleted = fileWorkItemRepository.Update(tempWorkItems[itemNumberToMark - 1]);

                    fileWorkItemRepository.SaveChanges();

                }

                else if (userChoice == "R" || userChoice == "r") {

                    var tempWorkItems = fileWorkItemRepository.GetAll();

                    WorkItem.PrintWorkItems(tempWorkItems);

                    Console.Write("Choose the number of the task you want to delete: ");

                    int itemNumberToDelete = int.Parse(Console.ReadLine());

                    fileWorkItemRepository.Remove(tempWorkItems[itemNumberToDelete - 1].Id);

                }

                else if (userChoice == "p")
                {

                    WorkItem.PrintWorkItems(fileWorkItemRepository.GetAll());

                }

                else if (userChoice == "q" || userChoice == "Q")
                {
                    return;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("[A]dd work item\n" +
                              "[B]uild a plan\n" +
                              "[M]ark workitem as comlited\n" +
                              "[R]emove a workitem\n" +
                              "[Q]uit the app");
        }

        
    }
}
