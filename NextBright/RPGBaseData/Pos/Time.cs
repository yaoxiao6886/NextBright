using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBaseData
{
    public abstract class Time : Singleton<Time>
    {
        protected abstract float OnGetDeltaTime();
        public static float deltaTime {
            get {
                return inst.OnGetDeltaTime();
            }
        }
       

        protected abstract float OnGetPastedSeconds();
        public static float realTimeSinceStartUp
        {
            get {
                return inst.OnGetPastedSeconds();
            }
        }
        
    }
}
