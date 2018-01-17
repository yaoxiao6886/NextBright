using RPGLogicBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilerImplementation : MonoBehaviour {

    class Implementation : Profiler {
        protected override void OnEndSample()
        {
            UnityEngine.Profiling.Profiler.EndSample();
        }

        protected override void OnStartSample(string name)
        {
            UnityEngine.Profiling.Profiler.BeginSample(name);
        }
    }


    

    // Use this for initialization
    void Awake () {
        Profiler.SetImplementation( new Implementation() );
	}
	

	void Update () {
		
	}
}
