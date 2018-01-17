using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGBaseTests.Tests;
using System;

namespace PuppetBehaviours.Tests
{
    public class PuppetTestBase
    {
        [TestInitialize()]
        public void InitEnvironment() {
            TestTime time = new TestTime();
            TestGameLoopController controller = new TestGameLoopController();
        }
    }
}