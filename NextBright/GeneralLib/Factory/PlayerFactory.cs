using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    /// <summary>
    /// 创建玩家的方法集合
    /// Facade Pattern, 注意: 这个跟Factory Method和Abstract Factory没有关系
    /// 事实上, 木偶的创建用了Builder模式, 详见Director和Builder
    /// </summary>
    public  class PlayerCreateHelper
    {
        /// <summary>
        /// 生成RPG游戏中正常的玩家
        /// 可以支持正常的技能, 移动, 跳跃等行为
        /// </summary>
        /// <returns></returns>
        public static Player CreateRPGPlayer(IPlayerStructs structs) {
            PlayerBuildDirector director = new PlayerBuildDirector();
            return director.BuildPlayer( new RPGPlayerBehavioursBuilder(structs));
        }
    }
}
