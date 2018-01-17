using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuppetBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGLogicBase;
using RPGBaseData;
using PuppetTests.Puppet.PuppetTestBase;

namespace PuppetBehaviours.Tests
{
    /// <summary>
    /// 测试木偶
    /// </summary>
    [TestClass()]
    public class PuppetBasicTests
    {
        /// <summary>
        /// 测试用行为子类, 主要测试是否接收到事件
        /// </summary>
        class TestBehave : DimentionalBehaviour
        {
            public int result;

            protected override void OnRegisteEvent(Eventer eventer)
            {
                eventer.RegisteEvent<int>( OnResult );
            }

            private void OnResult(int obj)
            {
                result = obj;
            }

            internal void SendMsg()
            {
               Base_NofityEvent<int>(2);
            }

            protected override void OnRegisteGameLoopEvent(GameLoopTrigger trigger)
            {

            }
        }

        
        /// <summary>
        /// 测试用子类, 主要搭建测试框架
        /// </summary>
        class TestPuppet : Puppet
        {
            public static TestBehave behav1 = new TestBehave();
            public static TestBehave behav2 = new TestBehave();
            

            public int result;
            public int calledTimes;

            public TestPuppet() : base(new Dictionary<DimentionEnum, DimentionalBehaviour>()
            {
                { DimentionEnum.POS, behav1},
                { DimentionEnum.ANIM, behav2}
            }){ }
            
            public void SendMsg() {
                Base_NotifyEvent<int>(1);
            }
            

            protected override void DefineCareEvents(Eventer eventer)
            {
                eventer.RegisteEvent<int>(x =>
                {
                    result = x;
                });
            }
            
            protected override void DefineGameLoopInterfaces(GameLoopTrigger eventer)
            {
                eventer.RegisteUpdate(OnUpdate, 2);
            }

            void OnUpdate() {
                calledTimes++;
            }
        }

        TestPuppet puppet;

        [TestInitialize()]
        public void Init() {
            PuppetTestUtils.Init();
            puppet = new TestPuppet();
        }

        [TestMethod()]
        public void 外部发事件内部接收()
        {
            puppet.SendMsg();

            Assert.AreEqual(1, TestPuppet.behav1.result );
            Assert.AreEqual(1, TestPuppet.behav2.result);
            Assert.AreEqual(1, puppet.result);
        }
        
        [TestMethod()]
        public void 内部发事件外部接收()
        {
            TestPuppet.behav1.SendMsg();

            Assert.AreEqual(2, TestPuppet.behav1.result);
            Assert.AreEqual(2, TestPuppet.behav2.result);
            Assert.AreEqual(2, puppet.result);
        }

        [TestMethod()]
        public void 刷帧接口检测() {
            PuppetTestUtils.trigger.CallBack();
            Assert.AreEqual(1, puppet.calledTimes);
        }
        
    }

}