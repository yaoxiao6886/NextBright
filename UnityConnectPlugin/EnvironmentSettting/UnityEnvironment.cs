using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityConnectPlugin
{
    /// <summary>
    /// Unity下的环境配置
    /// </summary>
    class UnityEnvironmentSetter
    {
        TimeImplementation time = new TimeImplementation();
        UpdateImplementation updateImplementation = new UpdateImplementation();
        ProfilerImplementation profiler = new ProfilerImplementation();
        LogImplementation log = new LogImplementation();
    }
}
