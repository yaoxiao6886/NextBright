using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    /// <summary>
    /// 玩家的创建Director
    /// Builder模式
    /// 由多种Director和多种Builder来构造Player
    /// Director本身应该不需要任何的继承关系, 不同Director构造需要的参数也不同, 
    /// 不需要继承
    /// 多种Director: 同一种Builder可以构造出不同的木偶(玩家, 怪物等)
    /// 多种Builder: 同一种Director可以构造出不同特性的制定木偶(浴池里的玩家等)
    /// </summary>
    internal class PlayerBuildDirector
    {

        public Player BuildPlayer( IBehavioursBuilder builder ) {

            var dict = new Dictionary<DimentionEnum, DimentionalBehaviour>();
            builder.SetBehaviours( dict );
            Player p = new Player(dict);
            return p;
        }

    }
}
