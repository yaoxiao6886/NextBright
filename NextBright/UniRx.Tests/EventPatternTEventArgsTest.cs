// <copyright file="EventPatternTEventArgsTest.cs" company="Microsoft">Copyright © Microsoft 2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniRx;

namespace UniRx.Tests
{
    /// <summary>This class contains parameterized unit tests for EventPattern`1</summary>
    [PexClass(typeof(EventPattern<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class EventPatternTEventArgsTest
    {
    }
}
