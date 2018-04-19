﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase 
    {
        protected ApplicationManager app;

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
            for (int i = 0; i < l; i++)
            {
              builder.Append( Convert.ToChar(Convert.ToInt32(r.NextDouble() * 223 + 21)));
            }
            return builder.ToString();
        }
    }
}
