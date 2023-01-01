using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Bson;
using Blackout.TaskPlanner.DataAccess.Abstraction;
using Xunit;
using Blackout.TaskPlanner.Domain.Models;
using Blackout.TaskPlanner.Domain.Logic;

namespace Blackout.TaskPlanner.Domain.Logic.Tests
{
    public class SimpleTaskPlannerTests
    {
        [Fact]
        public void CorrectSortingOfWorkItems() {
        
            var mock = new Mock<IWorkItemRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestWorkItems());
            var planner = new SimpleTaskPlanner(mock.Object);
        
        
            WorkItem[] result = planner.CreatePlan();
        
            WorkItem[] tempList = GetSortedWorkItems();
        
            Assert.True(CheckEquality(result, tempList));
        }

        [Fact]
        public void CorrectSelection() {
            var mock = new Mock<IWorkItemRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetSelectionWorkItems());
            var planner = new SimpleTaskPlanner(mock.Object);

            WorkItem[] result = planner.CreatePlan();

            WorkItem[] tempList = GetSelectedWorkItems();

            Assert.True(CheckEquality(result, tempList));
        }

        private bool CheckEquality(WorkItem[] firstArray, WorkItem[] secondArray)
        {
            //This method is really works
            if (firstArray.Length != secondArray.Length)
                return false;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i].ToString() != secondArray[i].ToString())
                    return false;
            }
            return true;
        }

        private WorkItem[] GetTestWorkItems() {

            var tempList = new List<WorkItem>
            {
                new WorkItem { Title = "the first", Description = "the first item", DueDate=DateTime.Today.AddDays(1), Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Days},
                new WorkItem { Title = "the second", Description = "the second item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.High, Complexity=Models.Enums.Complexity.Minutes},
                new WorkItem { Title = "the third", Description = "the third item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Hours},
                new WorkItem { Title = "the fourth", Description = "the fourth item", DueDate=DateTime.Today, Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Weeks},
                new WorkItem { Title = "the fifth", Description = "the fifth item", DueDate=DateTime.Today.AddDays(3), Priority=Models.Enums.Priority.Urgent, Complexity=Models.Enums.Complexity.Minutes},
                
            };

            return tempList.ToArray();
        }

        private WorkItem[] GetSortedWorkItems() {
            var tempList = new List<WorkItem> {
                new WorkItem { Title = "the fifth", Description = "the fifth item", DueDate=DateTime.Today.AddDays(3), Priority=Models.Enums.Priority.Urgent, Complexity=Models.Enums.Complexity.Minutes},
                new WorkItem { Title = "the second", Description = "the second item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.High, Complexity=Models.Enums.Complexity.Minutes},
                new WorkItem { Title = "the fourth", Description = "the fourth item", DueDate=DateTime.Today, Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Weeks},
                new WorkItem { Title = "the first", Description = "the first item", DueDate=DateTime.Today.AddDays(1), Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Days},
                new WorkItem { Title = "the third", Description = "the third item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Hours},

            };
            return tempList.ToArray();
        }

        private WorkItem[] GetSelectionWorkItems() {
            var tempList = new List<WorkItem>
            {
                new WorkItem { Title = "the first", Description = "the first item", DueDate=DateTime.Today.AddDays(1), Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Days, IsCompleted = true},
                new WorkItem { Title = "the second", Description = "the second item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.High, Complexity=Models.Enums.Complexity.Minutes, IsCompleted = false},
                new WorkItem { Title = "the third", Description = "the third item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Hours, IsCompleted = true},
                new WorkItem { Title = "the fourth", Description = "the fourth item", DueDate=DateTime.Today, Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Weeks, IsCompleted = false},
                new WorkItem { Title = "the fifth", Description = "the fifth item", DueDate=DateTime.Today.AddDays(3), Priority=Models.Enums.Priority.Urgent, Complexity=Models.Enums.Complexity.Minutes, IsCompleted = false},

            };

            return tempList.ToArray();
        }

        private WorkItem[] GetSelectedWorkItems()
        {
            var tempList = new List<WorkItem> {
                new WorkItem { Title = "the fifth", Description = "the fifth item", DueDate=DateTime.Today.AddDays(3), Priority=Models.Enums.Priority.Urgent, Complexity=Models.Enums.Complexity.Minutes},
                new WorkItem { Title = "the second", Description = "the second item", DueDate=DateTime.Today.AddDays(2), Priority=Models.Enums.Priority.High, Complexity=Models.Enums.Complexity.Minutes},
                new WorkItem { Title = "the fourth", Description = "the fourth item", DueDate=DateTime.Today, Priority=Models.Enums.Priority.Low, Complexity=Models.Enums.Complexity.Weeks},

            };
            return tempList.ToArray();
        }
    }
}
