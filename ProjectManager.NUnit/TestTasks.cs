using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectManager.API.Controllers;
using ProjectManager.Entities.DataModels;

using NUnit.Framework;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace ProjectManager.NUnit
{
    public class TestTasks
    {
        // Create a test for each Controller action. So we need 4 NUnit test cases
        TasksController tasksController = new TasksController();

        [Test]
        public void TestGetItems()
        {
            // Arrange Act Assert AAA

            // Act

            List<Tasks> myTasks = tasksController.GetTasks().ToList();

            // Assert
            CollectionAssert.AllItemsAreNotNull(myTasks);
        }

        [TestCase(3)]
        public void TestGetItemById(int Id)
        {
            //Task<IHttpActionResult> ExpectedOp;
            String ExpectedName = "Task Two updated";
            List<Tasks> result = tasksController.GetTasks(Id);
            //List<Tasks> myTasks = tasksController.GetTasks(Id);
            //Assert.AreEqual(Id, result.Id);
            Assert.AreEqual(ExpectedName, result.Find(data => data.Id == Id).Name);
        }

        [Test]
        public void TestPost()
        {
            Tasks testTask = new Tasks
            {
                Id = 0,
                status = false,
                Name = "Test task",
                Parent_Task = 1,
                Priority = 1,
                User = 99,
                Start_Date = Convert.ToDateTime("01/08/2019"),
                End_Date = Convert.ToDateTime("02/08/2019"),
                Project_Id = 1
            };
            //IHttpActionResult httpResult = tasksController.Post(testTask);
            var createdResult = tasksController.PostTasks(testTask) as CreatedAtRouteNegotiatedContentResult<Tasks>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["Id"]);
        }

        [Test]
        public void TestPut()
        {
            Tasks testTask = new Tasks
            {
                Id = 1,
                status = true,
                Name = "Eighth Task updated test result",
                Parent_Task = 1,
                Priority = 8,
                User = 99,
                Start_Date = Convert.ToDateTime("01/08/2019"),
                End_Date = Convert.ToDateTime("02/08/2019"),
                Project_Id = 1
            };

            var createdResult = tasksController.PutTasks(testTask) as StatusCodeResult;
            Assert.IsNotNull(createdResult);
            //Assert.IsInstanceOf(createdResult, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, createdResult.StatusCode);
        }
    }
}
