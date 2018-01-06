using PuppetBehaviours;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGLogicBase;
using RPGLogicBase;

namespace PuppetBehaviours.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        class FakePos : IPosControl
        {
            public GridPosF lastPos;
            public GridPosF GetPos()
            {
                return new GridPosF() { X = 1, Y = 1 };
            }

            public void SetPos(GridPosF pos)
            {
                lastPos = pos;
            }
        }

        class PlayerStructs : IPlayerStructs
        {
            public FakePos pos = new FakePos();

            public IAnimControl GetAnimControl()
            {
                return null;
            }

            public IPosControl GetPosControl()
            {
                return pos;
            }
        }

        [TestMethod()]
        public void MoveToPosTest()
        {
            PlayerStructs stru = new PlayerStructs();
            Player player = PlayerFactory.CreateRPGPlayer(stru);

            player.MoveTo( new GridPosF() { X = 6, Y=6 });

            Assert.AreEqual(6, stru.pos.lastPos.X);
            Assert.AreEqual(6, stru.pos.lastPos.Y);
        }
        
    }
}