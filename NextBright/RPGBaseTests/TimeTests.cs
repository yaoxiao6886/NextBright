using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBaseTests.Tests
{
    [TestClass()]
    public class TimeTests
    {
        [TestMethod()]
        public void 时间单例正常()
        {
            TestTime time = new TestTime();
            TestTime.SetTimeAndUpdate(3);
            Assert.AreEqual(3, Time.realTimeSinceStartUp);
        }
    }
}