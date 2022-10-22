using Blackout.TaskPlanner.Domain.Models;

namespace Blackout.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        

        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            //items = Sort(items);
            List<WorkItem> listItems = items.ToList();

            listItems.OrderBy(w => w.Title);

            listItems.Sort(new TaskComparer());
                    
            return listItems.ToArray();
        }

        private static WorkItem[] Sort(WorkItem[] workItems)
        {
            List<WorkItem> _workItems = workItems.ToList();

            var sortedWorkItems = from w in _workItems
                                  orderby w.Title
                                  select w;

            return sortedWorkItems.ToArray();
        }
    }
}