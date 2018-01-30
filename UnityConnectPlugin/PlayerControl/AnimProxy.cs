using PuppetBehaviours;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityConnectPlugin
{
    public class AnimProxy : IAnimControl
    {
        public TriggerGroupElement<Animation> anim = new TriggerGroupElement<Animation>(null);

        TriggerGroupElement<string> targetAnim = new TriggerGroupElement<string>("");

        TriggerGroupElement<AnimWrapMode> animWrapMode = new TriggerGroupElement<AnimWrapMode>(AnimWrapMode.Loop);
        
        public TriggerGroup animFlusher;

        public AnimProxy() {
            animFlusher = new TriggerGroup(Flush);
            animFlusher.AddTrigger(targetAnim);
            animFlusher.AddTrigger(anim);
            animFlusher.AddTrigger(animWrapMode);
        }

        public void PlayAnim(string animName, AnimWrapMode wrapMode)
        {
            animFlusher.Operate(opr =>
            {
                opr.SetValue(targetAnim, animName);
                opr.SetValue(animWrapMode, wrapMode);
            });
        }

        public void Flush()
        {
            Animation animation = anim.GetValue();
            if (animation != null) {
                animation.wrapMode = animWrapMode.GetValue().ToWrapMode();
                animation.CrossFade(Map(targetAnim.GetValue()));
            }
        }

        string Map(string originName) {
            switch (originName)
            {
                case "stand":
                    return "qiang_stand";
                case "walk":
                    return "qiang_walk";
            }

            return "qiang_stand";
        }

        public void SetAnim(Animation transform)
        {
            animFlusher.Operate(opr =>
            {
                opr.SetValue(anim, transform);
            });
        }
    }
}
