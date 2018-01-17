using RPGBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

class UpdateImplementation : GameLoopTrigger
{
    public override void RegisteUpdate(Action act, int time)
    {
        Observable.EveryUpdate().Buffer(TimeSpan.FromMilliseconds(time)).Subscribe(x => {
            act();
        });
    }
}