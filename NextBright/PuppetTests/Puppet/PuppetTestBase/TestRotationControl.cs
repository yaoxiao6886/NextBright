using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppetBehaviours;
using RPGLogicBase;

namespace PuppetTests.Puppet.PuppetTestBase
{
    class TestRotationControl : IRotationControl
    {
        Vector2 forwardDir;
        public Vector2 GetForwardDir()
        {
            return forwardDir;
        }

        public void SetForwardDir(Vector2 dir)
        {
            forwardDir = dir;
        }
    }
}
