using Blackout.TaskPlanner.DataAccess.Abstraction;
using Newtonsoft.Json;
using Blackout.TaskPlanner.Domain.Models;
using System.IO;
using System.Collections.Generic;


namespace Blackout.TaskPlanner.DataAccess
{
    public class FileWorkItemRepository : IWorkItemRepository
    {
        private const string FILE_NAME = "..\\..\\..\\..\\work-item.json";
        private readonly Dictionary<Guid, WorkItem> workItemsData = new Dictionary<Guid, WorkItem>();

        
        public FileWorkItemRepository()
        {
            if(!File.Exists(FILE_NAME))
            {
                File.Create(FILE_NAME).Close();
            }

            var json = File.ReadAllText(FILE_NAME);

            var dataWorkItems = JsonConvert.DeserializeObject<WorkItem[]>(json);

            if (dataWorkItems is not null)
            {

                for(int i = 0; i < dataWorkItems.Length; i++) {

                    workItemsData.Add(dataWorkItems[i].Id, dataWorkItems[i]);    

                }
                for (int i = 0; i < dataWorkItems.Length; i++)
                {

                    Console.WriteLine($"{i+1}. {dataWorkItems[i]}");

                }
            }
        }

        public Guid Add(WorkItem workItem)
        {
            WorkItem clonedWorkItem = workItem.Clone();

            clonedWorkItem.Id = Guid.NewGuid();

            workItemsData.Add(clonedWorkItem.Id, clonedWorkItem);

            SaveChanges();

            return clonedWorkItem.Id;

        }

        public WorkItem Get(Guid id)
        {
            return workItemsData[id];
        }

        public WorkItem[] GetAll()
        {
            return workItemsData.Values.ToArray();
        }

        public bool Remove(Guid id)
        {
            
            workItemsData.Remove(id);

            SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            var workItems = workItemsData.Values.ToArray(); 

            string json = JsonConvert.SerializeObject(workItems, Formatting.Indented);
            
            File.WriteAllText(FILE_NAME, json);
        }

        public bool Update(WorkItem workItem)
        {
            //workItemsData[workItem.Id] = workItem;
            return !workItem.IsCompleted;
        }
    }
}