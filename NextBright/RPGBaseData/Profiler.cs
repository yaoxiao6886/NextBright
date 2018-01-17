using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPGLogicBase;

namespace RPGLogicBase
{
    public abstract class Profiler  : Singleton<Profiler>
    {
        protected abstract void OnStartSample(string name);
        protected abstract void OnEndSample();

        public void BeginSample(string name) {
            OnStartSample(name);
        }

        public void EndSample() {
            OnEndSample();
        }
    }
}
