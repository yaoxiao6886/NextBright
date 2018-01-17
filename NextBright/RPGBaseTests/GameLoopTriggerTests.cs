using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBaseTests.Tests
{
    /// <summary>
    /// 测试游戏循环控制器
    /// </summary>
    [TestClass()]
    public class GameLoopTriggerTests
    {
        TestGameLoopController testController = null;//new TestGameLoopController();

        [TestInitialize()]
        public void Init() {
            testController = new TestGameLoopController();
        }
        
        /// <summary>
        /// 测试接口是否可以调用到子类上
        /// </summary>
        [TestMethod()]
        public void 子类收到调用()
        {
            GameLoopTrigger.inst.RegisteUpdate(TestMethod, 2);
            Assert.AreEqual(TestMethod, testController.myAct);
            Assert.AreEqual(2, testController.myTime);
        }

        private void TestMethod()
        {

        }
    }
}