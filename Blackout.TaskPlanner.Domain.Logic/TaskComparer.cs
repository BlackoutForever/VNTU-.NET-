using Blackout.TaskPlanner.Domain.Models;

namespace Blackout.TaskPlanner.Domain.Logic
{
    internal class TaskComparer : IComparer<WorkItem>
    {
        static public List<WorkItem> SortItemsByTitle(List<WorkItem> workitem) {
            var sortedWorkitem = from w in workitem
                                 orderby w.Title
                                 select w;

            return sortedWorkitem.ToList();
        }

        public int Compare(WorkItem w1, WorkItem w2) {
          
            if (w1.Priority < w2.Priority) return 1;
            if (w1.Priority > w2.Priority) return -1;

            if (w1.DueDate > w2.DueDate) return 1;
            if (w1.DueDate < w2.DueDate) return -1;

            return 0;
        }
    }
}
