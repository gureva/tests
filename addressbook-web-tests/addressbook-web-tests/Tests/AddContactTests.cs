using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests : TestBase
    {        
        [Test]
        public void AddContactTest()
        {
            //Contact init
            ContactData contact = new ContactData("Iva34n","I53anov");
            AccountData account = new AccountData("f", "d");
            app.Contacts.Create(contact);
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }    
    }
}
