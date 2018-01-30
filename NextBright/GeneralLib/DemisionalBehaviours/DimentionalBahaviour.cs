using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPGLogicBase;

namespace PuppetBehaviours
{
    /// <summary>
    /// 维度行为
    /// 维度: 互相不干涉即为维度, 如: 动作, 位置, 音乐等
    /// </summary>
    public  abstract class DimentionalBehaviour
    {
        Eventer eventer;

        public void RegisteEvent(Eventer eventer) {
            this.eventer = eventer;
            OnRegisteEvent(eventer);
            OnRegisteGameLoopEvent( GameLoopTrigger.inst );
        }

        protected abstract void OnRegisteGameLoopEvent(GameLoopTrigger trigger);

        protected abstract void OnRegisteEvent(Eventer eventer);

        protected void Base_NofityEvent<T>(T t) where T:struct
        {
            eventer.NotifyEvent<T>(t);
        }
        
    }
}
