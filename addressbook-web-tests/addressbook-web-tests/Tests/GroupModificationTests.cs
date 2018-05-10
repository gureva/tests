using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
   public  class GroupModificationTests : GroupTestBase
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

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[index - 1];

            app.Groups.Modify(toBeModified, changed);

            Assert.AreEqual(oldGroups.Count , app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();            

            oldGroups[index - 1].Name = changed.Name;
            //oldGroups.Sort();
            //newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(changed.Name, group.Name);
                }
            }
            // app.Auth.Logout();

        }
    }
}
