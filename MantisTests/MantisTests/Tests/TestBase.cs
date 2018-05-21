using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    public class TestBase 
    {
        protected ApplicationManager app;

        //для долгих проверок
        public static bool PERFORM_LONG_UI_CHECKS = true;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random r = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(r.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= l; i++)
            {
              builder.Append(Convert.ToChar(32 + Convert.ToInt32(r.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
