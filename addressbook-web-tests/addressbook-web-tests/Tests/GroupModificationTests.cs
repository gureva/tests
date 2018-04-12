using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
   public  class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            // group init
            GroupData changed = new GroupData("Changed");
            changed.Header = null;
            changed.Footer = "05";

            //номер группы для мофикации
            int index = 4;

            if (app.Groups.IsGroupListEmpty() || !app.Groups.IsIndex(index, 2))
            {
                index = app.Groups.CreateSomeGroup();
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(index, changed);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[index - 1].Name = changed.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            // app.Auth.Logout();

        }
    }
}
