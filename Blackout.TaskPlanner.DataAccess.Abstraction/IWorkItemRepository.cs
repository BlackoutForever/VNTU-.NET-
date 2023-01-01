using Blackout.TaskPlanner.Domain.Models;


namespace Blackout.TaskPlanner.DataAccess.Abstraction
{
    public interface IWorkItemRepository
    {

        Guid Add(WorkItem workItem);

        WorkItem Get(Guid id);

        WorkItem[] GetAll();

        bool Update (WorkItem workItem);

        bool Remove(Guid id);

        void SaveChanges();
    }
}