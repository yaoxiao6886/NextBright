using PuppetBehaviours;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class RotationImplementation : IRotationControl
{
    Transform transform;
    public RotationImplementation(Transform trm) {
        transform = trm; 
    } 

    public RPGLogicBase.Vector2 GetForwardDir()
    {
        Vector3 angles = transform.forward;
        return new RPGLogicBase.Vector2() { x = angles.x, y = angles.z };
    }

    public void SetForwardDir(RPGLogicBase.Vector2 dir)
    {
        float y = RPGLogicBase.Vector2.SignedAngle(RPGLogicBase.Vector2.zero, dir);
        //transform.eulerAngles = new Vector3(0, y, 0);
        transform.right = new Vector3( dir.y, 0 , -dir.x);
    }
}
