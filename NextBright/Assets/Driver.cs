using PuppetBehaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityConnectPlugin;
using UnityEngine;

public class Driver : MonoBehaviour {
    private Player player;

    public Transform PlayerTransform;
    public Camera CameraTransform;
        
  
    void Start () {
        player = PlayerFactory.CreatePlayer(PlayerTransform);
        player.SetPosChangedCallBack(OnPosChanged);
    }

    private void OnPosChanged(RPGLogicBase.Vector2 obj)
    {
        CameraTransform.transform.position = PlayerTransform.position + new Vector3(10, 10, 10);
    }
    
    float x = 0;
    float y = 0;
    public float speed = 1;
	void Update () {

        if (Input.GetMouseButton(0)) {
            Ray ray = CameraTransform.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                player.MoveTo(new RPGLogicBase.Vector2() { x = hitInfo.point.x, y = hitInfo.point.z });
            }
        }
    }
}
