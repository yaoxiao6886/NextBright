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
            eventer.RegisteEvent<IE_MovePos>( OnBeginWalk );
        }

        private void OnBeginWalk(IE_MovePos obj)
        {
            animControl.PlayAnim("walk");
        }
    }
}