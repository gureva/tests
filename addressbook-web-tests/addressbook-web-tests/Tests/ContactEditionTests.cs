using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactEditionTests : AuthTestBase
    {

        [Test]
        public void ContactEditionTest()
        {
            ContactData contact = new ContactData("Liza", "Jhons");

            app.Contacts.Edit(1, contact);
            //app.Auth.Logout();
        }
    }
}
