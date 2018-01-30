using RPGLogicBase;

namespace UnityConnectPlugin
{
    public class LogImplementation : Debug
    {
        public LogImplementation()
        {
        }

        protected override void OnLog(string s)
        {
            UnityEngine.Debug.Log(s);
        }
    }
}