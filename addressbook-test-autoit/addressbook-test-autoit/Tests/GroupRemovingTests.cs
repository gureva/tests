using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupToRemove = new GroupData() { Name = "test" };

            // если не будет группы, удалит первую
            int index = 1;

            for (int i = 1;i < oldGroups.Count(); i ++)
            {
                if (oldGroups[i].Name == groupToRemove.Name)
                {
                    index = i;
                    break;
                }
            }

            app.Groups.RemoveGroup(index);

            oldGroups.RemoveAt(index);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
