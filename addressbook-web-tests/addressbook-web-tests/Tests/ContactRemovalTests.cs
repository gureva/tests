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
             
            app.Contacts.Remove(index);
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

            app.Contacts.Delete(index);
            //app.Auth.Logout();
        }
    }
}
