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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Edit(index, contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[index - 1].FirstName = contact.FirstName;
            oldContacts[index - 1].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //app.Auth.Logout();
        }
    }
}
