using System;
using RPGLogicBase;

namespace PuppetBehaviours
{
    class PlayerAnimBehaviour : DimentionalBehaviour
    {
        private IAnimControl animControl;

        Triggable<string> currentAnim;

        public PlayerAnimBehaviour(IAnimControl animControl)
        {
            this.animControl = animControl;
            currentAnim = new Triggable<string>("stand", OnAnimChanged);
            animControl.PlayAnim("stand", AnimWrapMode.Loop);
        }

        private void OnAnimChanged(string orignValue, string newValue)
        {
            animControl.PlayAnim(newValue, AnimWrapMode.Loop);
        }

        protected override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IE_MovePos>( OnBeginWalk );
            eventer.RegisteEvent<IE_ArriveTarget>(OnArriveTarget);
        }

        private void OnArriveTarget(IE_ArriveTarget obj)
        {
            currentAnim.SetValue("stand");
        }

        protected override void OnRegisteGameLoopEvent(GameLoopTrigger trigger)
        {

        }

        private void OnBeginWalk(IE_MovePos obj)
        {
            currentAnim.SetValue( "walk");
        }
    }
}