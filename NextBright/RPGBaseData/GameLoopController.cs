﻿using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGLogicBase
{
    /// <summary>
    /// 游戏循环触发器
    /// 游戏循环(Update等)
    /// 所有需要使用游戏循环的内容, 注册回调
    /// 设计目标:
    ///     1. 不依赖Unity自身的Update, LateUpdate等基础, 抽象出一个独立于引擎的逻辑
    ///     2. 默认注册都是每帧检测, 而是1s检测若干次, 从根本上优化性能
    ///     3. 最不重要的一点, 不需要Update, LateUpdate的精灵, 不会调用, 没有性能消耗
    /// </summary>
    public abstract class GameLoopTrigger : Singleton<GameLoopTrigger>
    {
        /// <summary>
        /// 注册Update事件
        /// </summary>
        /// <param name="act">回调行为</param>
        /// <param name="millsecond">
        /// 间隔, 0为每帧都调用
        /// 为性能考虑, 默认为200ms, 也就是1s走5次
        /// </param>
        public abstract void RegisteUpdate(Action act, int millsecond = 200);
        
        
    }
}
