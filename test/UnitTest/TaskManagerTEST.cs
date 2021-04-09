using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Xunit;
using Moq;
using DAL;
using BLL;
using FluentAssertions;

namespace UnitTest
{
    public class TaskManagerTEST
    {
        private readonly Mock<ITaskManagerRepository> mockrepository;

        public TaskManagerTEST()
        {
            mockrepository = new Mock<ITaskManagerRepository>();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void getTaskTest(int expected, int numberOfTask)
        {
            var listOfTask = new List<Task>();
            for (int i = 0; i < numberOfTask; i++)
            {
                listOfTask.Add(new Task
                {
                    TaskId = i,
                    Description = "job" + i,
                    DueDate = DateTime.Now,
                    IsCompleted = false,
                    Assignee = new Assignee
                    {
                       Id = i,
                       Name = "Assignee" + i,
                    }
                });
            }
            mockrepository.Setup(x => x.getAllTasks()).Returns(listOfTask);
            var taskManager = new TaskManager(mockrepository.Object);
            var result = taskManager.getAllTasks().ToList().Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetTasksEmptyList()
        {
            var listOfTask = new List<Task>();

            mockrepository.Setup(x => x.getAllTasks()).Returns(listOfTask);
            var taskManager = new TaskManager(mockrepository.Object);
            Action ac = () => taskManager.getAllTasks();
            ac.Should().Throw<ArgumentException>().WithMessage("No Tasks Found!");
        }
    }
}
