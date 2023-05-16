using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Control.Test
{
    [TestClass]
    public class ControlTest
    {

        [TestMethod]
        public void TestIncorrectLogin()
        {
            string login = "testLogin";
            string password = "Aa123456789@";
            bool result = CollegeApp.Classes.Control.CheckEnter(login, password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIncorrectPassword()
        {
            string login = "golovkora";
            string password = "testP@ssw0rd";
            bool result = CollegeApp.Classes.Control.CheckEnter(login, password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEmptyLogin()
        {
            string login = "";
            string password = "Aa123456789@";
            bool result = CollegeApp.Classes.Control.CheckEnter(login, password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEmptyPassword()
        {
            string login = "";
            string password = "Aa123456789@";
            bool result = CollegeApp.Classes.Control.CheckEnter(login, password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCorrectData()
        {
            string login = "golovkora";
            string password = "Aa123456789@";
            bool result = CollegeApp.Classes.Control.CheckEnter(login, password);
            Assert.IsTrue(result);
        }
    }
}
