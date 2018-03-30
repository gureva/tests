using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {        
        [Test]
        public void AddContactTest()
        {
            //Contact init
            ContactData contact = new ContactData("Bob","Snow");
            //AccountData account = new AccountData("f", "d");
            app.Contacts.Create(contact);
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }    
    }
}
