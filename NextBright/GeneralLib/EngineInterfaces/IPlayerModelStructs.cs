using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    public  interface IPlayerStructs
    {
        IPosControl GetPosControl();

        IAnimControl GetAnimControl();
    }
}
