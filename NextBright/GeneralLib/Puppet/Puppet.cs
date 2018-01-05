using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    /// <summary>
    /// 木偶（Puppet）：所有游戏中可以被操控的物体都被称为木偶
    /// 自己无法决定自身行为, 接受外界指示改变自身状态, 只考虑
    /// 如何实现外界要求, 不考虑下一步要做什么
    /// 责任: 事件注册与派发, 木偶维度行为管理
    /// </summary>
    public  abstract  class Puppet
    {
        /// <summary>
        /// 木偶身上现有的维度行为
        /// </summary>
        Dictionary< DimentionEnum, DimentionalBahaviour> behaviourList = new Dictionary<DimentionEnum, DimentionalBahaviour>();

        public Puppet(Dictionary<DimentionEnum, DimentionalBahaviour> list)
        {
            this.behaviourList = list;

            RegisteEvents();
        }

        /// <summary>
        /// 事件者
        /// 木偶和维度行为在同一事件空间里,
        /// 木偶或者任一维度行为的事件, 其他
        /// 木偶和维度行为都能听到
        /// </summary>
        Eventer eventer = new Eventer();

        protected void RegisteEvents() {
            //维度行为注册关心事件
            foreach (var pair in behaviourList)
            {
                InitBehvaiour(pair.Value);
            }
            //木偶注册关心事件
            DefineCareEvents(eventer);
        }
        

        /// <summary>
        /// 强制要求子类定义关心的事件
        /// </summary>
        /// <param name="eventer"></param>
        protected abstract void DefineCareEvents(Eventer eventer);


        /// <summary>
        /// 初始化调用组件行为
        /// </summary>
        /// <param name="bah"></param>
        void InitBehvaiour(DimentionalBahaviour bah) {
            //注册事件
            bah.RegisteEvent(eventer);
        }

        /// <summary>
        /// 通知事件空间中的物体事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        protected void Base_NotifyEvent<T>(T t) where T : struct {
            eventer.NotifyEvent<T>(t);
        }
        

        ///// <summary>
        ///// 通知事件空间中的物体事件
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="init"></param>
        //protected void Base_NotifyEvent<T>(Action<ref T> init) where T : struct {
        //    T t = new T();
        //    init(t);
        //    Base_NotifyEvent(t);
        //}
    }
}
