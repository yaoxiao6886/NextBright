using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityConnectPlugin
{
    /// <summary>
    /// Ogre库对外接口
    /// 使用Ogre库需要将此脚本挂载在一个空挂点下
    /// 脚本自动创建所需元素
    /// 设计目标:
    ///     对外使用简单
    ///     挂载脚本, 所有逻辑自动实现
    /// Facade Pattern
    /// </summary>
    public  class Ogre : MonoBehaviour
    {
        UnityEnvironmentSetter setter = new UnityEnvironmentSetter();

    }
}
