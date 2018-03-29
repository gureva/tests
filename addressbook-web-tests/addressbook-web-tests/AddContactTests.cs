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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddContactPage();

            //Contact init
            ContactData contact = new ContactData("Iva34n","I53anov");

            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            Logout();
        }    
    }
}
