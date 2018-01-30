using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    /// <summary>
    /// 触发组
    /// 1. 当组中有任意数据变化时, 都会触发回调
    /// 2. 当组内有多个数据同时变化时, 只触发一次回调
    /// </summary>
    /// <typeparam name="T">成组的参数集合</typeparam>
    public struct TriggerGroup
    {
        /// <summary>
        /// 子元素需要实现接口
        /// </summary>
        public interface IHasChange {
            /// <summary>
            /// 数据是否变化
            /// </summary>
            /// <returns></returns>
            bool HasChange();
            /// <summary>
            /// 清除变化标记
            /// </summary>
            void ClearChangeMark();
        }
        
        /// <summary>
        /// 触发组操作器
        /// </summary>
        public struct TriggerGroupOperator {
            private HashSet<IHasChange> valueSet;

            /// <summary>
            /// 构造操作器
            /// </summary>
            /// <param name="set"></param>
            public TriggerGroupOperator(HashSet<IHasChange> set) {
                valueSet = set;
            }

            /// <summary>
            /// 给待操作的元素设置新值
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="t">待操作的元素</param>
            /// <param name="newValue">新值</param>
            public void SetValue<T>(TriggerGroupElement<T> t, T newValue){
                if (!valueSet.Contains(t)) {
                    return;
                }
                
                t.SetValue(newValue);
            }
        }

        /// <summary>
        /// 被设置的元素
        /// </summary>
        HashSet<IHasChange> valueSet;
        /// <summary>
        /// 变化的回调
        /// </summary>
        Action callBack;

        /// <summary>
        /// 变化前回调
        /// </summary>
        Action beforeChange;

        /// <summary>
        /// 初始化回调
        /// </summary>
        /// <param name="callBack"></param>
        public TriggerGroup(Action callBack, Action beforeChange = null) {
            valueSet = new HashSet<IHasChange>();
            this.callBack = callBack;
            this.beforeChange = beforeChange;
        }

        /// <summary>
        /// 增加Trigger
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void AddTrigger(IHasChange obj){
            valueSet.Add(obj);
        }

        /// <summary>
        /// 成组操作内部元素
        /// </summary>
        /// <param name="trigerOpr">操作的函数</param>
        public void Operate(Action<TriggerGroupOperator> trigerOpr) {
            beforeChange?.Invoke();

            trigerOpr(new TriggerGroupOperator(valueSet));

            bool needCallback = false;
            foreach (var value in valueSet) {
                if (value.HasChange()) {
                    value.ClearChangeMark();
                    needCallback = true;
                }
            }

            if (needCallback) {
                callBack();
            }
        }
    }
    
}
