using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    public abstract class Debug : Singleton<Debug>
    {
        protected abstract void OnLog(string s);

        public static void Log(string s) {
            inst.OnLog(s);
        }

        public static void LogFormatly(string s, params object[] objs ) {
            inst.OnLog(string.Format(s,objs));
        }
    }
}
