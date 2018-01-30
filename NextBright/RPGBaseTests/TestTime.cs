using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBaseTests.Tests
{
    public  class TestTime : Time
    {
        public TestTime() {
            pastedSeconds = 0;
        }

        static float pastedSeconds = 0;
        public static void SetTimeAndUpdate(float second) {
            pastedSeconds = second;
            TestGameLoopController.inst.CallBack();
        }

        protected override float OnGetDeltaTime()
        {
            return 0;
        }

        protected override float OnGetPastedSeconds()
        {
            return pastedSeconds;
        }
    }
}
