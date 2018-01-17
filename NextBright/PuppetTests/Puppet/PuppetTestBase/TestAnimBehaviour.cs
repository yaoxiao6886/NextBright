using PuppetBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetTests.Puppet.PuppetTestBase
{
    /// <summary>
    /// 测试脚本
    /// </summary>
    class TestAnimControl : IAnimControl
    {
        public string orderedName = "";
        public void PlayAnim(string animName)
        {
            orderedName = animName;
        }
    }

}
