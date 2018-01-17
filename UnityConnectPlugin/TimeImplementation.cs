using RPGBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityConnectPlugin
{
    class TimeImplementation : Time
    {
        protected override float OnGetDeltaTime()
        {
            return UnityEngine.Time.deltaTime;
        }

        protected override float OnGetPastedSeconds()
        {
            return UnityEngine.Time.realtimeSinceStartup;
        }
    }
}
