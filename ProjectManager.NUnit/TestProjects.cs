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

namespace ProjectManager.NUnit
{
    [TestFixture]
    public class TestProjects
    {
        ProjectsController projectsController = new ProjectsController();

        [Test]
        public void TestGetItems()
        {
            // Arrange Act Assert AAA

            // Act
            List<Projects> myProjects = projectsController.GetProjects();

            // Assert
            CollectionAssert.AllItemsAreNotNull(myProjects);
        }

        [TestCase(1)]
        public void TestGetItemById(int Id)
        {
            string ExpectedName = "First Project";
            Projects myProject = projectsController.GetProjects(Id);
            Assert.AreEqual(ExpectedName, myProject.Name);
        }

        [Test]
        public void TestPost()
        {
            Projects testProject = new Projects
            {
                Id = 0,
                Name = "Testing Project",
                Start_Date = DateTime.Today,
                End_Date = DateTime.Today,
                Priority = 5,
                Manager_Id = 1,
                status = false
            };
            //IHttpActionResult httpResult = tasksController.Post(testTask);
            var createdResult = projectsController.PostProjects(testProject) as CreatedAtRouteNegotiatedContentResult<Projects>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["Id"]);
        }

        [Test]
        public void TestPut()
        {
            Projects testProject = new Projects
            {
                Id = 4,
                Name = "Testing Project",
                Start_Date = DateTime.Today,
                End_Date = DateTime.Today,
                Priority = 5,
                Manager_Id = 1,
                status = false
            };

            var createdResult = projectsController.PutProjects(testProject.Id, testProject) as StatusCodeResult;
            Assert.IsNotNull(createdResult);
            //Assert.IsInstanceOf(createdResult, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, createdResult.StatusCode);
        }
    }
}
