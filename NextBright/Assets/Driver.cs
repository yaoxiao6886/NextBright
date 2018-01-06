using PuppetBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {
    private Player player;
    PlayerStructs playerStruct;

    float targetTime = 0;
    void Start () {
        playerStruct = GetComponent<PlayerStructs>();
        player = PlayerFactory.CreateRPGPlayer(playerStruct); // new Player( GetComponent<PosImplementation>() );

        targetTime = Time.realtimeSinceStartup + Random.Range(0, 5f);
    }

    // Update is called once per frame

    float x = 0;
    float y = 0;
    public float speed = 1;
	void Update () {


        if (Input.GetKey(KeyCode.W)) {
            x += speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)) {
            x -= speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.A)) {
            y -= speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D)) {
            y += speed * Time.deltaTime;
        }

        if (Time.realtimeSinceStartup > targetTime) {
            targetTime = float.MaxValue;
            playerStruct.animControl.SetAnim( transform.FindChild("bodyctrl").GetComponent<Animation>() );
        }

        player.MoveTo(new RPGLogicBase.GridPosF() { X =y, Y = x });
    }
}
