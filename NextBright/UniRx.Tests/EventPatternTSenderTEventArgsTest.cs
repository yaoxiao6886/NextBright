// <copyright file="EventPatternTSenderTEventArgsTest.cs" company="Microsoft">Copyright © Microsoft 2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniRx;

namespace UniRx.Tests
{
    /// <summary>This class contains parameterized unit tests for EventPattern`2</summary>
    [PexClass(typeof(EventPattern<, >))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class EventPatternTSenderTEventArgsTest
    {
        /// <summary>Test stub for TestInt(Int32)</summary>
        [PexGenericArguments(typeof(int), typeof(int))]
        [PexMethod]
        public void TestIntTest<TSender,TEventArgs>([PexAssumeUnderTest]EventPattern<TSender, TEventArgs> target, int i)
        {
            target.TestInt(i);
            // TODO: add assertions to method EventPatternTSenderTEventArgsTest.TestIntTest(EventPattern`2<!!0,!!1>, Int32)
        }
    }
}
