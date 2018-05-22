using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace MantisTests 
{    
    [TestFixture]
    public class AccountCreationTest : TestBase
    {
        private string CurrentTestFolder = TestContext.CurrentContext.TestDirectory;

        [SetUp]
        public void setUpConfig()
        {

            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localfile = File.Open(CurrentTestFolder + "/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localfile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testUser1011",
                Password = "123",
                email = "testuser1011@localhost.localdomain"
            };
            
            app.James.DeleteAccount(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
