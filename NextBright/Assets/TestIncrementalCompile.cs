﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIncrementalCompile : MonoBehaviour {

    static int i = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        i = 5;
        Debug.Log(i);
	}
}
