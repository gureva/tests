using System;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            AccountData ac = new AccountData()
            {

                Name = "xxx",
                Password = "yyy"
            };
           Assert.IsFalse(app.James.Verify(ac));
            app.James.Add(ac);
           Assert.IsTrue(app.James.Verify(ac));
            app.James.DeleteAccount(ac);
            Assert.IsFalse(app.James.Verify(ac));
        }
    }
}
