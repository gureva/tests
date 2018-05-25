using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTests()
        {
            AccountData account = new AccountData()
            { Name = "administrator", Password = "root"};
            ProjectData project = new ProjectData()
            {
                Id = "6"
            };
            IssueData issue = new IssueData()
            {
                Summary = "some txt",
                Description = "some long txt",
                Category = "General"
            };
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
