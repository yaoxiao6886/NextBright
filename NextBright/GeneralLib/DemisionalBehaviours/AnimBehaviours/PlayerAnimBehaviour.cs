using System;
using RPGLogicBase;

namespace PuppetBehaviours
{
    internal class PlayerAnimBehaviour : DimentionalBahaviour
    {
        private IAnimControl animControl;

        public PlayerAnimBehaviour(IAnimControl animControl)
        {
            this.animControl = animControl;
        }

        public override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IV_BeginWalk>( OnBeginWalk );
        }

        private void OnBeginWalk(IV_BeginWalk obj)
        {
            animControl.PlayAnim("walk");
        }
    }
}