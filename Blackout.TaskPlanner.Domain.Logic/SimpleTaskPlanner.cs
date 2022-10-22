using Blackout.TaskPlanner.Domain.Models;

namespace Blackout.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        

        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            items = Sort(items);
            var listItems = items.ToList();

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