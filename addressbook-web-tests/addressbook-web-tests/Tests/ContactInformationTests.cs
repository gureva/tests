﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformation()
        {
            int index = 0;

         ContactData fromTable = app.Contacts.GetContactInfoFromTable(index);
         ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(index);

         Assert.AreEqual(fromTable, fromForm);
         Assert.AreEqual(fromTable.Address, fromForm.Address);
         Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
         Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactView()
        {
            int index = 1;
            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(index);

            Assert.AreEqual(fromForm.InfoFormString, app.Contacts.GetContactInfoFromView(index));
        }

    }
}
