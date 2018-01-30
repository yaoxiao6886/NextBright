using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuppetBehaviours;
using PuppetTests.Puppet.PuppetTestBase;
using RPGBaseTests.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetBehaviours.Tests
{
    [TestClass()]
    public class PlayerPosBehaviourTests : PuppetTestBase
    {
        PlayerPosBehaviour posBehaviour = null;
        PuppetBehaviourIniter initer = null;
        TestPosControl posControl = null;
        [TestInitialize()]
        public void TestInit() {
            posControl = new TestPosControl();
            posBehaviour = new PlayerPosBehaviour(posControl);
            initer = new PuppetBehaviourIniter(posBehaviour);
        }

        [TestMethod()]
        public void 移动到目标()
        {
            RPGLogicBase.Vector2 pos = new RPGLogicBase.Vector2() { x = 10, y = 0 };
            initer.NotifyEvent(new IE_MovePos() { Pos= pos });
            TestTime.SetTimeAndUpdate(1);
            Assert.AreEqual(new RPGLogicBase.Vector2() { x =5, y=0}, posBehaviour.posControl.GetPos());
            TestTime.SetTimeAndUpdate(2);
            Assert.AreEqual(pos, posBehaviour.posControl.GetPos() );
        }

        [TestMethod()]
        public void 频繁移动() {
            float currTime = 0;
            RPGLogicBase.Vector2 pos = new RPGLogicBase.Vector2() { x = 10, y = 0 };
            while (currTime < 2) {
                pos += new RPGLogicBase.Vector2(-0.01f, 0f);
                initer.NotifyEvent(new IE_MovePos() { Pos = pos });
                TestTime.SetTimeAndUpdate(currTime+=0.1f);
            }

            Assert.AreEqual(pos, posBehaviour.posControl.GetPos());
        }
    }
}