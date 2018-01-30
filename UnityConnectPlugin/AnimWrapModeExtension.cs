using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityConnectPlugin
{
    public static class AnimWrapModeExtension
    {
        public static WrapMode ToWrapMode( this AnimWrapMode mode) {
            switch (mode) {
                case AnimWrapMode.Once:
                    return WrapMode.Once;
                case AnimWrapMode.Loop:
                    return WrapMode.Loop;
                case AnimWrapMode.OnceAndStopAtEnd:
                    return WrapMode.ClampForever;
                case AnimWrapMode.PingPong:
                    return WrapMode.PingPong;
            }

            return WrapMode.Loop;
        }
    }
}
