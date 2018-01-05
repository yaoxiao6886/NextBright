using System;
using RPGLogicBase;
using RPGLogicBase;

namespace PuppetBehaviours
{
    /// <summary>
    /// 玩家位置维度的行为
    /// </summary>
    internal class PlayerPosBehaviour : DimentionalBahaviour
    {
        public IPosControl posControl;

        public PlayerPosBehaviour(IPosControl control) {
            posControl = control;
        }

        public override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IE_MovePos>(OnMoveToPos);
        }

        private void OnMoveToPos(IE_MovePos obj)
        {
            posControl.SetPos(obj.Pos);
        }
    }
}