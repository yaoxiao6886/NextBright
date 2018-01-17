// <copyright file="PexAssemblyInfo.cs" company="Microsoft">Copyright © Microsoft 2018</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("UniRx")]
[assembly: PexInstrumentAssembly("UnityEngine.UnityWebRequestModule")]
[assembly: PexInstrumentAssembly("UnityEngine.UnityWebRequestWWWModule")]
[assembly: PexInstrumentAssembly("UnityEngine.AnimationModule")]
[assembly: PexInstrumentAssembly("UnityEngine.UI")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("UnityEngine.CoreModule")]
[assembly: PexInstrumentAssembly("UnityEngine.Physics2DModule")]
[assembly: PexInstrumentAssembly("UnityEngine.PhysicsModule")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.UnityWebRequestModule")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.UnityWebRequestWWWModule")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.AnimationModule")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.UI")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.CoreModule")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.Physics2DModule")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "UnityEngine.PhysicsModule")]

