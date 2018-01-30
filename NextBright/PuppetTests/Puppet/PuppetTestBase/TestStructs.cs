using PuppetBehaviours;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetTests.Puppet.PuppetTestBase
{
    class TestStructs : IPlayerStructs
    {
        public TestPosControl pos = new TestPosControl();
        public TestAnimControl anim = new TestAnimControl();
        public TestRotationControl rot = new TestRotationControl();

        public IAnimControl GetAnimControl()
        {
            return anim;
        }

        public IPosControl GetPosControl()
        {
            return pos;
        }

        public IRotationControl GetRotationControl()
        {
            return rot;
        }
    }
}
