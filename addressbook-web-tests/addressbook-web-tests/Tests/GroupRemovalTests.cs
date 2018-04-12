using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 3;
            if (app.Groups.IsGroupListEmpty() || !app.Groups.IsIndex(index,2))
            {
                index = app.Groups.CreateSomeGroup();
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(index);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

            GroupData toBeRemoved = oldGroups[index - 1];
            
            oldGroups.RemoveAt(index - 1);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

            //app.Auth.Logout();
        }  
        
    }
}
