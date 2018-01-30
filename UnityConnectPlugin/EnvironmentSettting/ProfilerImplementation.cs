using RPGLogicBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    class ProfilerImplementation : Profiler {
        protected override void OnEndSample()
        {
            UnityEngine.Profiling.Profiler.EndSample();
        }

        protected override void OnStartSample(string name)
        {
            UnityEngine.Profiling.Profiler.BeginSample(name);
        }
    }
