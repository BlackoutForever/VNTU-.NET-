using Blackout.TaskPlanner.Domain.Logic;
using Blackout.TaskPlanner.Domain.Models;

namespace Blackout.TaskPlanner.ConsoleRunner
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WorkItem[] workItems;
            SimpleTaskPlanner stp = new();


            while (true)
            {
                Console.Write("Enter the number of the tasks you wanna create: ");
                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int numberOfTasks))
                {
                    workItems = new WorkItem[numberOfTasks];

                    for (int i = 0; i < numberOfTasks; i++)
                    {
                        workItems[i] = new WorkItem();
                    }

                    
                    WorkItem.PrintWorkItems(workItems);
                    


                    workItems = stp.CreatePlan(workItems);

                    WorkItem.PrintWorkItems(workItems);

                    

                    return;
                }
                else Console.WriteLine("You've entered the wrong value! Try again...");
            }
        }  
    }
}
