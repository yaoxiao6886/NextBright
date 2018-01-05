using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuppetBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGLogicBase;

namespace PuppetBehaviours.Tests
{
    /// <summary>
    /// 测试木偶
    /// </summary>
    [TestClass()]
    public class PuppetTests
    {
        /// <summary>
        /// 测试用行为子类, 主要测试是否接收到事件
        /// </summary>
        class TestBehave : DimentionalBahaviour
        {
            public int result;

            public override void OnRegisteEvent(Eventer eventer)
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
        }

        
        /// <summary>
        /// 测试用子类, 主要搭建测试框架
        /// </summary>
        class TestPuppet : Puppet
        {
            public static TestBehave behav1 = new TestBehave();
            public static TestBehave behav2 = new TestBehave();
            

        public int result;

            public TestPuppet() : base(new Dictionary<DimentionEnum, DimentionalBahaviour>()
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
        }

        TestPuppet puppet = new TestPuppet();

        /// <summary>
        /// 测试从外部发事件, 内部是否可以接收
        /// </summary>
        [TestMethod()]
        public void PuppetTest()
        {
            puppet.SendMsg();

            Assert.AreEqual(1, TestPuppet.behav1.result );
            Assert.AreEqual(1, TestPuppet.behav2.result);
            Assert.AreEqual(1, puppet.result);
        }

        /// <summary>
        /// 测试从内部发事件, 外部是否可以接收
        /// </summary>
        [TestMethod()]
        public void PuppetTestFromInner()
        {
            TestPuppet.behav1.SendMsg();

            Assert.AreEqual(2, TestPuppet.behav1.result);
            Assert.AreEqual(2, TestPuppet.behav2.result);
            Assert.AreEqual(2, puppet.result);
        }
        
    }

}