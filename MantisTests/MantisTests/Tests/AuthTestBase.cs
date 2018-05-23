using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Login.Login(new AccountData()
            {
                Name = "administrator", Password = "root"
            });
        }
    }
}
