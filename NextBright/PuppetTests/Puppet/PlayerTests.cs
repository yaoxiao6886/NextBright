using PuppetBehaviours;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGLogicBase;
using PuppetTests.Puppet.PuppetTestBase;
using RPGBaseTests.Tests;

namespace PuppetBehaviours.Tests
{
    [TestClass()]
    public class PlayerTests : PuppetTestBase
    {
        #region 公用测试用基础
        private TestStructs stru;
        private Player player;

        /// <summary>
        /// 初始化数据
        /// </summary>
        [TestInitialize()]
        public void InitData()
        {
            stru = new TestStructs();
            player = PlayerFactory.CreateRPGPlayer(stru);
        }
        #endregion
        
        [TestMethod()]
        public void 位置接入()
        {
            player.MoveTo( new Vector2() { x = 6, y=6 });

            TestTime.SetTimeAndUpdate(100);

            Assert.AreEqual(6, stru.pos.GetPos().x);
            Assert.AreEqual(6, stru.pos.GetPos().y);
        }

        [TestMethod()]
        public void 动画接入() {
            player.MoveTo(new Vector2() { x = 6, y = 6 });
            Assert.AreEqual("walk", stru.anim.orderedName);
        }
    }
}