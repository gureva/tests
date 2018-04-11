using System;
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

            app.Groups.Remove(index);
            //app.Auth.Logout();
        }             
    }
}
