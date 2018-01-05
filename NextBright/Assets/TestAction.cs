using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class TestAction : MonoBehaviour {

    interface ITest {

    }

    struct T : ITest {
        public int i;
    }

    Delegate c;

	// Use this for initialization
	void Start () {
        SetDelegate(OnClick);

    }

    void SetDelegate(Action<T> act) {
        c = act;
    }

    private void OnClick(T obj)
    {

    }

    // Update is called once per frame
    void Update () {
        Action<T> call = c as Action<T>;

        call(new T());
	}
}
