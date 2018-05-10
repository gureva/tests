using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactEditionTests : ContactTestBase
    {

        [Test]
        public void ContactEditionTest()
        {
            //Номер контакта для редактирования
            int index = 1;

            if (app.Contacts.IsContactListEmpty() || !app.Contacts.IsIndex(index,1))
            {
                index = app.Contacts.CreateSomeContact();
            }

            ContactData contactModified = new ContactData("Liza1", "Jhons1");

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[index];

            app.Contacts.Edit(toBeModified, contactModified);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[index].FirstName = contactModified.FirstName;
            oldContacts[index].LastName = contactModified.LastName;
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
        }
    }
}
