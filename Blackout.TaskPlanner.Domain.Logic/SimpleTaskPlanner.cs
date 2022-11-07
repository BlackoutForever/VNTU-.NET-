using Blackout.TaskPlanner.Domain.Models;
using Blackout.TaskPlanner.Domain.Logic;

namespace Blackout.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        

        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            
            List<WorkItem> listItems = items.ToList();

            listItems = TaskComparer.SortItemsByTitle(listItems);

            listItems.Sort(new TaskComparer());
                    
            return listItems.ToArray();
        }
    }
}