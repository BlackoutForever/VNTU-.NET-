using Blackout.TaskPlanner.Domain.Models;

namespace Blackout.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        

        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            
            List<WorkItem> listItems = items.ToList();

            listItems.OrderBy(w => w.Title);

            listItems.Sort(new TaskComparer());
                    
            return listItems.ToArray();
        }
    }
}