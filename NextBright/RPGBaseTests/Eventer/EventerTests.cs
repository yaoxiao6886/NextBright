using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase.Tests
{
    [TestClass()]
    public class EventerTests
    {
        [TestMethod]
        public void 接收单一事件()
        {
            Eventer target = new Eventer();
            int result = 0;
            target.RegisteEvent<int>(x =>
            {
                result = x;
            });
            target.NotifyEvent<int>(1);
            Assert.AreEqual(1, result);
        }
        
        [TestMethod]
        public void 接收多次注册事件()
        {
            Eventer target = new Eventer();
            int result1 = 0;
            target.RegisteEvent<int>(x =>
            {
                result1 = x;
            });
            int result2 = 0;
            target.RegisteEvent<int>(x =>
            {
                result2 = x;
            });
            target.NotifyEvent<int>(1);
            Assert.AreEqual(1, result1);
            Assert.AreEqual(1, result2);
        }
    }
}