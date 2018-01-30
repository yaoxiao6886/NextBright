using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBaseTests.Tests
{
    /// <summary>
    /// 测试用Controller
    /// </summary>
    public class TestGameLoopController : GameLoopTrigger
    {
        public static new TestGameLoopController inst {
            get {
                return GameLoopTrigger.inst as TestGameLoopController;
            }
        }

        public Action myAct;
        public int myTime;
                
        public void CallBack()
        {
            myAct();
        }

        public override void RegisteUpdate(Action act, int time)
        {
            this.myAct += act;
            this.myTime = time;
        }
    }
}
