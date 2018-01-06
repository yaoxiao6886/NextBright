using UnityEngine;
using PuppetBehaviours;
using RPGLogicBase;
using System;

public class PlayerStructs : MonoBehaviour, IPlayerStructs
{
    IPosControl control = null;
    public AnimProxy animControl = new AnimProxy();

    private void Awake()
    {
        control = GetComponent<PosImplementation>();
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
        animControl.Flush();
    }
}


public class AnimProxy : IAnimControl
{
    public Animation anim = null;

    string targetAnim = "";

    bool needFlush = false;

    public void PlayAnim(string animName)
    {
        if (targetAnim != animName) {
            needFlush = true;
        }

        targetAnim = animName;
    }

    public void Flush() {
        if (needFlush && anim != null) {
            anim.CrossFade(targetAnim);
        }
    }

    internal void SetAnim(Animation transform)
    {
        anim = transform;
    }
}