using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            string text = "13";
            app.Contacts.SearchContact(text);
            int number = app.Contacts.GetNumberSearchResults();
            int rows = app.Contacts.GetRowsNumber();

            Assert.AreEqual(number, rows);
        }                
    }
}
