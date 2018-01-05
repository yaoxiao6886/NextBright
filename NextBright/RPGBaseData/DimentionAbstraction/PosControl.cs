
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGLogicBase
{
    /// <summary>
    /// 基本位置控制接口
    /// 由具体引擎实现
    /// </summary>
    public interface IPosControl
    {
        GridPosF GetPos();

        void SetPos(GridPosF pos);
    }
}
