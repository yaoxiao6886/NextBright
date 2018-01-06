
using RPGLogicBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosImplementation : MonoBehaviour, IPosControl
{
    public GridPosF GetPos()
    {
        return new GridPosF() { X = transform.position.x, Y = transform.position.y };
    }

    public void SetPos(GridPosF pos)
    {
        transform.position = new Vector3(pos.X, transform.position.y, pos.Y);
    }
    
}
