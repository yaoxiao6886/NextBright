using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    /// <summary>
    /// Singleton在项目中支持两种用法
    /// 第一种:
    ///     A: Singleton<A>{
    ///         protected abstract int OnFuncA();
    ///         public static int A(){
    ///             return OnFuncA();
    ///         }
    ///     }
    ///     这种方法的好处在于既用了Singleton, 可以动态替换单例, 同时外界又用Static方法调用, 可以省去调用GetInstance的不便
    /// 第二种:
    ///     B: Singleton<B>{
    ///         public abstract int FuncA();
    ///     }
    ///     这种是传统单例, 外界可以用B作为参数来回传递, 避免大家需要记忆类型的不便
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T: Singleton<T>
    {
        static T _inst = null;
        /// <summary>
        /// 单例
        /// </summary>
        public static T inst {
            get {
                return _inst;
            }
        }

        /// <summary>
        /// 允许替换SingleTon
        /// </summary>
        public Singleton() {
            _inst = this as T;
        }
    }
}
