using PuppetBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityConnectPlugin
{
    public  class PlayerFactory
    {
        public static Player CreatePlayer(Transform root ) {
            return PlayerCreateHelper.CreateRPGPlayer(new PlayerStructs(root));
        }
    }
}
