using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    /// <summary>
    /// 成组的Trigger的成员
    /// TriggerGroup需要使用此元素
    /// </summary>
    /// <typeparam name="T">成员类型</typeparam>
    public class TriggerGroupElement<T> : TriggerGroup.IHasChange
    {
        T realValue;
        bool isChanged;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="t">默认值</param>
        public TriggerGroupElement(T t) {
            realValue = t;
            isChanged = false;
        }

        /// <summary>
        /// 是否发生值发生变化
        /// </summary>
        /// <returns></returns>
        public bool HasChange()
        {
            return isChanged;
        }

        /// <summary>
        /// 获取当前值
        /// </summary>
        /// <returns></returns>
        public T GetValue() {
            return realValue;
        }

        /// <summary>
        /// 清除标记
        /// </summary>
        public void ClearChangeMark()
        {
            isChanged = false;
        }

        /// <summary>
        /// 不对库外暴露
        /// 对于使用者而言, 他应该看到只能是这个只可以Get
        /// 至于Set, 需要到加入的组中进行处理
        /// </summary>
        /// <param name="value"></param>
        internal void SetValue(T value) {
            bool isSame = false;
            if (typeof(T).IsValueType)
            {
                //值类型, 直接比对
                isSame = realValue.Equals(value);
            }
            else {
                //引用类型, 走==
                object origin = realValue as Object;
                object newValue = value as Object;
                isSame = origin == newValue;
            }

            realValue = value;
            isChanged = true;
        }
        
    }
}
