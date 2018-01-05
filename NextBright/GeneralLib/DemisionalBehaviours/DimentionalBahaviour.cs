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
    public  abstract class DimentionalBahaviour
    {
        Eventer eventer;

        public void RegisteEvent(Eventer eventer) {
            this.eventer = eventer;
            OnRegisteEvent(eventer);
        }

        public abstract void OnRegisteEvent(Eventer eventer);

        protected void Base_NofityEvent<T>(T t) where T:struct
        {
            eventer.NotifyEvent<T>(t);
        }

        //protected void Base_NofityEvent<T>(Action<T> init) where T : struct {
        //    T t = new T();
        //    init(t);
        //    Base_NofityEvent<T>(t);
        //}
    }
}
