using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    /// <summary>
    /// 玩家行为的Builder, 定义玩家的Builder
    /// </summary>
    internal  class RPGPlayerBehavioursBuilder : IBehavioursBuilder
    {
        IPlayerStructs modelStruct = null;
        public RPGPlayerBehavioursBuilder(IPlayerStructs structs ) {
            modelStruct = structs;
        }

        public void SetBehaviours(Dictionary<DimentionEnum, DimentionalBehaviour> dict )
        {
            dict.Add(DimentionEnum.POS, new PlayerPosBehaviour(modelStruct.GetPosControl()));
            dict.Add(DimentionEnum.ANIM, new PlayerAnimBehaviour(modelStruct.GetAnimControl()));
            dict.Add(DimentionEnum.ROT, new PlayerRotationBehaviour(modelStruct.GetRotationControl()));
        }
    }
}
