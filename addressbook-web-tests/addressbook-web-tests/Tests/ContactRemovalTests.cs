using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //Номер контакта для удаления
            int index = 2;

            if (app.Contacts.IsContactListEmpty() || !app.Contacts.IsIndex(index, 1))
            {
                index = app.Contacts.CreateSomeContact();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(index);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(index - 1);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }

        [Test]
        public void DeleteContactTest()
        {
            int index = 2;

            if (app.Contacts.IsContactListEmpty() || !app.Contacts.IsIndex(index, 1))
            {
                index = app.Contacts.CreateSomeContact();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Delete(index);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(index - 1);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //app.Auth.Logout();
        }
    }
}
