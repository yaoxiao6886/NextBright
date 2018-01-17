using System;
using RPGBaseData;
using RPGLogicBase;

namespace PuppetBehaviours
{
    class PlayerAnimBehaviour : DimentionalBehaviour
    {
        private IAnimControl animControl;

        public PlayerAnimBehaviour(IAnimControl animControl)
        {
            this.animControl = animControl;
        }

        protected override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IE_MovePos>( OnBeginWalk );
        }

        protected override void OnRegisteGameLoopEvent(GameLoopTrigger trigger)
        {

        }

        private void OnBeginWalk(IE_MovePos obj)
        {
            animControl.PlayAnim("walk");
        }
    }
}