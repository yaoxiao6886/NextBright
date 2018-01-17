using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuppetBehaviours;
using PuppetTests.Puppet.PuppetTestBase;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetBehaviours.Tests
{
    /// <summary>
    /// 测试玩家动作的行为
    /// </summary>
    [TestClass()]
    public class PlayerAnimBehaviourTests
    {


        private TestAnimControl animControl;
        private PlayerAnimBehaviour control;
        private Eventer eventer;
        
        /// <summary>
        /// 构造新实例
        /// 每次测试时, 重新生成Eventer和实例
        /// </summary>
        [TestInitialize()]
        public void Initialize() {
            //虚拟驱动PlayerAnimBehaviour
            animControl = new TestAnimControl();
            control = new PlayerAnimBehaviour(animControl);
            eventer = new Eventer();
            control.RegisteEvent(eventer);
        }
        
        [TestMethod()]
        public void 收到移动请求时播移动动作()
        {
            eventer.NotifyEvent(new IE_MovePos() );
            Assert.AreEqual(animControl.orderedName, "walk");
        }
    }
}