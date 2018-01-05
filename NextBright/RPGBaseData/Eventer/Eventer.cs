using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RPGLogicBase;

namespace RPGLogicBase
{


    /// <summary>
    /// 事件管理者
    /// 掌管事件的监听和派发
    /// 游戏中以结构体为事件，结构体的类型为key，确保不重复
    /// 可以通用，需要复杂监听时可以直接使用Eventer
    /// 
    /// 优势:
    ///     Dispatch时本身无GC产生
    /// </summary>
    public class Eventer
    {
            Dictionary<Type, Delegate > msgDict = new Dictionary<Type, Delegate >();

            public void RegisteEvent<T>(Action<T> callBack) where T:struct {
                Type t = typeof(T);
                if (msgDict.ContainsKey(t))
                {
                    msgDict[t] = Delegate.Combine( msgDict[t], callBack);
                }
                else {
                    msgDict.Add(t,  callBack );
                }            
            }
                
            [DebuggerHidden()]
            public void NotifyEvent<T>(T t) where T : struct {
                Type type = typeof(T);
            
                if (msgDict.ContainsKey(type))
                {
                    Action<T> act = msgDict[type] as Action<T>;
                    act(t);
                }
            }

     }
}
