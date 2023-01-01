using Blackout.TaskPlanner.Domain.Models.Enums;

namespace Blackout.TaskPlanner.Domain.Models
{
    
    public class WorkItem
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;

        //
        // Constructors
        //
        //
        
        public WorkItem(bool forClone = false) {
            if (!forClone)
            {
                Title = SetWorkItemTitle();
                Description = SetWorkItemDescription();

                DueDate = SetWorkItemDueDate();

                Priority = SetWorkitemPriority();
                Complexity = SetWorkitemComplexity();

                ToString();
            }
        }

        public WorkItem() { }
    

        //
        // Methods
        //
        public override string ToString() => $"{Title}: {Description} | due {DueDate.ToString("dd.MM.yyyy")}, {Priority.ToString().ToUpper()} priority | {Complexity} | {IsCompleted} | {CreationDate.ToString("dd.MM.yyyy")}.";


        public WorkItem Clone()
        {
           return new WorkItem
            {
                CreationDate = CreationDate,
                DueDate = DueDate,
                Priority = Priority,
                Complexity = Complexity,
                Title = Title,
                Description = Description,
                IsCompleted = IsCompleted,

            };
        }
        


        // Prints the array of the WorkItems
        public static void PrintWorkItems(WorkItem[] workitem)
        {
            int i = 1;
            Console.WriteLine("|----------------------------------------------");
            foreach (WorkItem item in workitem)
            {
                Console.WriteLine($"| {i}. " + item);
                i++;
            }
            Console.WriteLine("|----------------------------------------------");
        }

        /// Sets the Priority due to Enum.TryParse
        private Priority SetWorkitemPriority()
        {
            Console.WriteLine("|----------------------------------------------");
            Console.Write("| Enter the priority of the task:\n" + 
                          "| None\n" + 
                          "| Low\n" + 
                          "| Medium\n" + 
                          "| High\n" + 
                          "| Urgent\n" + 
                          "|-----------------\n" + 
                          "| Your choice: ");

            string enteredPriority = Console.ReadLine();

            if (Enum.TryParse(enteredPriority, true, out Priority priority) && ((enteredPriority != null) || enteredPriority != ""))
            {
                return priority;
            }

            return Priority.None;

        }

        // Sets the Complexity due to Enum.TryParse
        private Complexity SetWorkitemComplexity()
        {
            Console.WriteLine("|----------------------------------------------");
            Console.Write("| Enter the complexity of the task:\n" + 
                          "| None\n" + 
                          "| Minutes\n" +
                          "| Hours\n" + 
                          "| Days\n" + 
                          "| Weeks\n" + 
                          "|-----------------\n" + 
                          "| Your choice: ");
            string enteredComplexity = Console.ReadLine();
            Console.WriteLine("|----------------------------------------------");

            if (Enum.TryParse(enteredComplexity, true, out Complexity complexity) && ((enteredComplexity != null) || enteredComplexity != ""))
            {
                return complexity;
            }

            return Complexity.None;

        }

        // Sets the Due Date
        private DateTime SetWorkItemDueDate()
        {
            Console.WriteLine("|----------------------------------------------");
            Console.Write("| Enter the due date of the task: ");
            string enteredDueDate = Console.ReadLine();

            if (enteredDueDate == "") return DateTime.Now;

            return DateTime.Parse(enteredDueDate);
        }

        // Sets the Title 
        private string SetWorkItemTitle() {
            Console.WriteLine("|----------------------------------------------");
            Console.Write("| Enter the title of the task: ");
            string? enteredTitle = Console.ReadLine();
            if (enteredTitle == "" || enteredTitle == " ") return "TaskItem Title";

            return enteredTitle;
        }

        //Sets the Description
        private string SetWorkItemDescription()
        {
            Console.WriteLine("|----------------------------------------------");
            Console.Write("| Enter the description of the task: ");
            string enteredDescription = Console.ReadLine();
            if (enteredDescription == "" || enteredDescription == " ") return "TaskItem Description";

            return enteredDescription;
        }

        //Sets the completion


        
    }
}