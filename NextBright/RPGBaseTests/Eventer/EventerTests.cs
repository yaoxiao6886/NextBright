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
        /// <summary>
        /// 测试正常的事件派发
        /// </summary>
        [TestMethod]
        public void TestSingleEvent()
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

        /// <summary>
        /// 测试多次注册时间派发
        /// </summary>
        [TestMethod]
        public void TestMulitpleRegisteEvent()
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