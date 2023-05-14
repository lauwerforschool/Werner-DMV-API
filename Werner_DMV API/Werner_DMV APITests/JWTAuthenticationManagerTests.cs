using Microsoft.VisualStudio.TestTools.UnitTesting;
using Werner_DMV_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werner_DMV_API.Controllers;

//test to see if user credentials are correct

namespace Werner_DMV_API.Tests
{
    [TestClass()]
    public class JWTAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateTest()
        {
            JWTAuthenticationManager manager = new JWTAuthenticationManager("fakaelogin");

            User user = new User
            {
                username = "test",
                password = "pass"
            };

            var ret = manager.Authenticate(user.username, user.password); //is this a valid username/password

            Assert.IsNull(ret); //no, so its null
        }
    }
}