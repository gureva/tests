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
            //Номер контакта для редактирования
            int index = 2;

            if (app.Contacts.IsContactListEmpty() || !app.Contacts.IsIndex(index,1))
            {
                index = app.Contacts.CreateSomeContact();
            }

            ContactData contact = new ContactData("Liza", "Jhons");

            app.Contacts.Edit(index, contact);
            //app.Auth.Logout();
        }
    }
}
