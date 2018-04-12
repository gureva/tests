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

            ContactData contactModified = new ContactData("Liza", "Jhons");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Edit(index, contactModified);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeModified = oldContacts[index - 1];

            oldContacts[index - 1].FirstName = contactModified.FirstName;
            oldContacts[index - 1].LastName = contactModified.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(contactModified.FirstName, contact.FirstName);
                    Assert.AreEqual(contactModified.LastName, contact.LastName);
                }
            }
            //app.Auth.Logout();
        }
    }
}
