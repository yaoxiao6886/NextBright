using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    /// <summary>
    /// Wrapper
    /// 但不是Wrapper Pattern
    /// 提供一个当值发生变化时, 触发的Wrapper
    /// !!!不可以使用默认构造函数
    /// </summary>
    /// <typeparam name="T">存储值的类型</typeparam>
    public  struct Triggable<T>
    {
        /// <summary>
        /// 回调接口
        /// 没有用Action是因为, 希望自动生成代码时, 可以生成参数名
        /// </summary>
        /// <param name="orignValue">原值</param>
        /// <param name="newValue">新值</param>
        public delegate void CallBack(T orignValue, T newValue);
        /// <summary>
        /// 实际存储值
        /// </summary>
        T value;
        /// <summary>
        /// 回调接口
        /// </summary>
        CallBack callBack;

        /// <summary>
        /// 必须的构造函数
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="callback"></param>
        public Triggable(T defaultValue, CallBack callback){
            value = defaultValue;
            callBack = callback;
        }
        
        /// <summary>
        /// 设置新值
        /// </summary>
        /// <param name="newValue"></param>
        public void SetValue(T newValue) {
            if (value.Equals(newValue) )
            {
                return;
            }

            T originValue = value;
            value = newValue;

            callBack(originValue, newValue);            
        }
        
        /// <summary>
        /// 获得当前值 
        /// </summary>
        /// <returns></returns>
        public T GetValue() {
            return value;
        }
    }
}
