﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResearchManager;
using ResearchManager.Controllers;
using System.Web;
using Moq;

namespace ResearchManager.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest

    {
        /*[TestMethod]
        public void SignIn()
        {
            // Arrange
            HomeController controller = new HomeController();
            Entities db = new Entities();
            db.users.Add(new user
                {
                    Email="test@test.com",
                    forename="test",
                    surname="test",
                    staffPosition="Dean",
                    hash="test",
                    salt="test",
                    Matric="150014251"
                });
            db.SaveChanges();
            // Act
            var addedUser = db.users.Where(u => u.Email == "test@test.com").First();
            RedirectResult result = controller.viewSignIn(addedUser.staffPosition) as RedirectResult;
            db.users.Remove(addedUser);
            db.SaveChanges();

            // Assert
            Assert.IsNotNull(result);
        }
        */

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
