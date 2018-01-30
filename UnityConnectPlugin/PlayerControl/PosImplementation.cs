
using PuppetBehaviours;
using RPGLogicBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosImplementation : IPosControl
{
    Transform transform;
    public PosImplementation(Transform transform) {
        this.transform = transform;
    }
    public void SetPos(RPGLogicBase.Vector2 pos)
    {
        transform.position = new Vector3() { x = pos.x, z = pos.y };
    }

    RPGLogicBase.Vector2 IPosControl.GetPos()
    {
        return new RPGLogicBase.Vector2() { x = transform.position.x, y = transform.position.y };
    }
}
