using UnityEngine;
using PuppetBehaviours;
using UnityConnectPlugin;
using RPGLogicBase;

/// <summary>
/// 玩家数据结构
/// </summary>
public struct PlayerStructs : IPlayerStructs
{
    IPosControl control;
    AnimProxy animControl;
    Transform temp;
    IRotationControl rotControl;

    float targetTime;

    public PlayerStructs(Transform trans) {
        //注意 此时可以将AnimProxy传给Model
        temp = trans;
        control = new PosImplementation(trans);
        animControl = new AnimProxy();
        targetTime = RPGLogicBase.Time.realTimeSinceStartUp + Random.Range(0, 5f);
        rotControl = new RotationImplementation(trans);

        GameLoopTrigger.inst.RegisteUpdate(Update);
    }

    public IPosControl GetPosControl()
    {
        return control;
    }

    public IAnimControl GetAnimControl()
    {
        return animControl;
    }

    void Update() {
        

        if (RPGLogicBase.Time.realTimeSinceStartUp > targetTime)
        {
            targetTime = float.MaxValue;
            animControl.SetAnim(temp.Find("bodyctrl").GetComponent<Animation>());
        }

        animControl.Flush();
    }

    public IRotationControl GetRotationControl()
    {
        return rotControl;
    }
}

