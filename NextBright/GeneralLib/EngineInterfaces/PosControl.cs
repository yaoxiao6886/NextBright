
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    /// <summary>
    /// 基本位置控制接口
    /// 由具体引擎实现
    /// </summary>
    public interface IPosControl
    {
        Vector2 GetPos();

        void SetPos(Vector2 pos);
    }
}
