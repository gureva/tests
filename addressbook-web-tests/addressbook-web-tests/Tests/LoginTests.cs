using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCred()
        {
            app.Auth.Logout();

            AccountData admin = new AccountData("admin", "secret");
            app.Auth.Login(admin);

            Assert.IsTrue(app.Auth.isLoggedIn(admin));
        }

        [Test]
        public void LoginWithInvalidCred()
        {
            app.Auth.Logout();

            AccountData admin = new AccountData("admin", "secret11");
            app.Auth.Login(admin);

            Assert.IsFalse(app.Auth.isLoggedIn(admin));
        }
    }
}
