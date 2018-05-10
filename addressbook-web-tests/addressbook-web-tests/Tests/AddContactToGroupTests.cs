using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    public class ContactInGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            //выбираем нулевую группу
            GroupData group = GroupData.GetAll()[0];
            // список контактов в группе
            List<ContactData> oldList = group.GetContacts();

            //берём первый контакт, который не находится в 0 группе
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact,group);

            List<ContactData> newList = group.GetContacts();

            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(newList, oldList);
        }

        [Test]
        public void TestRemoveContactFromGroup()
        {
            //выбираем нулевую группу
            GroupData group = GroupData.GetAll()[0];
            // список контактов в группе
            List<ContactData> oldList = group.GetContacts();

           ContactData contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(newList, oldList);
        }
    }
}
