using PuppetBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {
    private Player player;

    void Start () {
        player = PlayerFactory.CreateRPGPlayer(GetComponent<PlayerStructs>()); // new Player( GetComponent<PosImplementation>() );
    }
	
	// Update is called once per frame
	void Update () {
        player.Move( new RPGLogicBase.GridPosF() { X = Random.Range(0,10), Y = Random.Range(0,10) });
        Try(new TestA());
    }

    interface C { }
    struct TestA : C {

    }

    void Try<T>(T c) where T:C {

    }
}
