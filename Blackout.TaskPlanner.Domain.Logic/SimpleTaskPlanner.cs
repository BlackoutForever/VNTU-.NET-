using Blackout.TaskPlanner.Domain.Models;
using Blackout.TaskPlanner.Domain.Logic;
using Blackout.TaskPlanner.DataAccess.Abstraction;
using System.Linq;

namespace Blackout.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        
        private IWorkItemRepository repo;

        public SimpleTaskPlanner(IWorkItemRepository repository) {
            repo = repository;
        }

        public WorkItem[] CreatePlan()
        {

            List<WorkItem> listItems = repo.GetAll().ToList();

            listItems = TaskComparer.SortItemsByTitle(listItems);

            var tempListItems = from item in listItems
                                   where item.IsCompleted == false
                                   select item;

            listItems = tempListItems.ToList();

            listItems.Sort(new TaskComparer());
                    
            return listItems.ToArray();
        }
    }
}