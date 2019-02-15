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
    public class TestUsers
    {
        UsersController usersController = new UsersController();

        [Test]
        public void TestGetItems()
        {
            // Arrange Act Assert AAA

            // Act
            List<Users> myUsers = usersController.GetUsers().ToList();

            // Assert
            CollectionAssert.AllItemsAreNotNull(myUsers);
        }

        [TestCase(1)]
        public void TestGetItemById(int Id)
        {
            string ExpectedName = "Singh";
            Users myUser = usersController.GetUsers(Id);
            Assert.AreEqual(ExpectedName, myUser.Last_Name);
        }

        [Test]
        public void TestPost()
        {
            Users testUser = new Users
            {
                Id = 0,
                First_Name = "Part",
                Last_Name = "Two"
            };
            //IHttpActionResult httpResult = tasksController.Post(testTask);
            var createdResult = usersController.PostUsers(testUser) as CreatedAtRouteNegotiatedContentResult<Users>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["Id"]);
        }

        [Test]
        public void TestPut()
        {
            Users testUser = new Users
            {
                Id = 3,
                First_Name = "Swaroop",
                Last_Name = "Last Name Changed"
            };

            var createdResult = usersController.PutUsers(testUser.Id, testUser) as StatusCodeResult;
            Assert.IsNotNull(createdResult);
            //Assert.IsInstanceOf(createdResult, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, createdResult.StatusCode);
        }

    }
}
