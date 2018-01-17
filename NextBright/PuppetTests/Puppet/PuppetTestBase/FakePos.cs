using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppetTests.Puppet.PuppetTestBase
{
    class TestPosControl : IPosControl
    {
        Vector2 lastPos;
        public Vector2 GetPos()
        {
            return lastPos;
        }

        public void SetPos(Vector2 pos)
        {
            lastPos = pos;
        }
    }
}
