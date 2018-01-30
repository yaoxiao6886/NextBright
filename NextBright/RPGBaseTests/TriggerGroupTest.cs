using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGLogicBase;
using System.ComponentModel;

namespace RPGBaseTests
{
    /// <summary>
    /// Summary description for TriggerGroupTest
    /// </summary>
    [TestClass]
    public class TriggerGroupTest
    {
        [TestMethod]
        public void 改值回调()
        {
            TriggerGroupElement<int> i = new TriggerGroupElement<int>(2);
            TriggerGroupElement<float> j = new TriggerGroupElement<float>(1.0f);

            int calledTimes = 0;
            TriggerGroup group = new TriggerGroup(()=> {
                calledTimes++;
            });

            group.AddTrigger(i);
            group.AddTrigger(j);

            group.Operate( opr=>{
                opr.SetValue(i, 3);
            }
            );

            Assert.AreEqual(calledTimes, 1);

            group.Operate(opr => {
                opr.SetValue(i, 5);
                opr.SetValue(j, 2f);
            }
            );

            Assert.AreEqual(calledTimes, 2);

            group.Operate(value =>
            {
                int TestResult = i.GetValue();
            });

            Assert.AreEqual(calledTimes, 2);
        }
    }
}
