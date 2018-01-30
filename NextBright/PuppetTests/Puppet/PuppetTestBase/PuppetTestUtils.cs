using PuppetBehaviours;
using RPGBaseTests.Tests;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetTests.Puppet.PuppetTestBase
{
    /// <summary>
    /// 布偶脚本测试用初始化
    /// </summary>
    class PuppetBehaviourIniter
    {
        Eventer eventer = new Eventer();

        public PuppetBehaviourIniter(DimentionalBehaviour b) {
            b.RegisteEvent(eventer);
        }

        public void NotifyEvent<T>(T t) where T : struct {
            eventer.NotifyEvent(t);
        }
    }

    
    class PuppetTestUtils {

        public  static TestGameLoopController trigger = null;// new TestGameLoopController();

        public static void Init() {
            trigger = new TestGameLoopController();
        }
        
    }
}
