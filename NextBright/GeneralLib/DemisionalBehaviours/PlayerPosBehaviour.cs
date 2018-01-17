using System;
using RPGBaseData;
using RPGLogicBase;

namespace PuppetBehaviours
{
    /// <summary>
    /// 玩家位置维度的行为
    /// </summary>
    internal class PlayerPosBehaviour : DimentionalBehaviour
    {
        public IPosControl posControl;
        Vector2 currentPos;
        Vector2 fromPos;
        Vector2 targetPos;
        float startTime = 0;
        float targetTime = 0;
        float speed = 5;

        public PlayerPosBehaviour(IPosControl control) {
            posControl = control;
            currentPos = control.GetPos();
        }

        protected override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IE_MovePos>(OnMoveToPos);
        }

        protected override void OnRegisteGameLoopEvent(GameLoopTrigger trigger)
        {
            trigger.RegisteUpdate(OnUpdate);
        }

        private void OnUpdate()
        {
            CalculatePos();
        }

        private void OnMoveToPos(IE_MovePos obj)
        {
            targetPos = obj.Pos;

            GenerateTimeSpan();
            
            CalculatePos();
        }

        private void GenerateTimeSpan()
        {
            float distance = Vector2.Distance(targetPos, currentPos);
            float needTime = distance / speed;
            fromPos = currentPos;
            startTime = Time.realTimeSinceStartUp;
            targetTime = startTime + needTime;
        }

        void CalculatePos() {
            float percent = Mathf.InverseLerp( startTime, targetTime, Time.realTimeSinceStartUp );
            currentPos = Vector2.Lerp(fromPos, targetPos, percent);
            posControl.SetPos(currentPos);
        }
    }
}