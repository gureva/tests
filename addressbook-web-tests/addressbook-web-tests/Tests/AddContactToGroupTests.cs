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
            if (app.Groups.IsGroupListEmpty())
            {
                app.Groups.CreateSomeGroup();
            }

            if (app.Contacts.IsContactListEmpty())
            {
                app.Contacts.CreateSomeContact();
            }

            //выбираем нулевую группу
            GroupData group = GroupData.GetAll()[0];
            // список контактов в группе
            List<ContactData> oldList = group.GetContacts();

            //берём первый контакт, который не находится в 0 группе
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //если все контакты в группе, создаём новый контакт
            if (contact == null)
            {
                app.Contacts.CreateSomeContact();
            }

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
            if (app.Groups.IsGroupListEmpty())
            {
               app.Groups.CreateSomeGroup();
            }

            if (app.Contacts.IsContactListEmpty())
            {
                app.Contacts.CreateSomeContact();
            }

            //выбираем нулевую группу
            GroupData group = GroupData.GetAll()[0];
            // список контактов в группе
            List<ContactData> oldList = group.GetContacts();
            ContactData contact;

            // если группа пустая
            if (oldList.Count() == 0)
            {
                contact = ContactData.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(contact, group);
                oldList = group.GetContacts();
            }
            else
            {
                 contact = oldList.First();
            }

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(newList, oldList);
        }
    }
}
