using System;
using RPGLogicBase;

namespace PuppetBehaviours
{
    /// <summary>
    /// 玩家位置维度的行为
    /// </summary>
    internal class PlayerPosBehaviour : DimentionalBehaviour
    {
        enum State {
            STAND,
            MOVE
        }

        State state = State.STAND;

        /// <summary>
        /// 目标位置
        /// </summary>
        TriggerGroupElement<Vector2> targetPos = new TriggerGroupElement<Vector2>(Vector2.zero);
        /// <summary>
        /// 速度
        /// </summary>
        TriggerGroupElement<float> speed = new TriggerGroupElement<float>(5);
        /// <summary>
        /// 计算组
        /// </summary>
        private TriggerGroup timeSpanCalculator;
        /// <summary>
        /// 目标时间
        /// </summary>
        float targetTime;
        /// <summary>
        /// 起点
        /// </summary>
        Vector2 fromPos;
        /// <summary>
        /// 当前点
        /// </summary>
        Triggable<Vector2> currentPos;
        /// <summary>
        /// 启动时间
        /// </summary>
        float startTime;
        /// <summary>
        /// 位置设置接口
        /// </summary>
        public IPosControl posControl;

        /// <summary>
        /// 初始化接口
        /// </summary>
        /// <param name="control"></param>
        public PlayerPosBehaviour(IPosControl control) {
            posControl = control;
            currentPos = new Triggable<Vector2>( control.GetPos(), OnCurrentPosChanged );

            timeSpanCalculator = new TriggerGroup(RecalulateTimeSpan, OnBeforeChange);
            timeSpanCalculator.AddTrigger(targetPos);
            timeSpanCalculator.AddTrigger(speed);
        }

        private void OnBeforeChange()
        {
            if (state == State.MOVE)
            {
                CalculatePos();
            }
        }

        private void OnCurrentPosChanged(Vector2 orignValue, Vector2 newValue)
        {
            Base_NofityEvent(new IE_PosChanged() { pos = newValue, originPos = orignValue });
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="eventer"></param>
        protected override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IE_MovePos>(OnMoveToPos);
            eventer.RegisteEvent<IE_SpeedChange>((me) => {
                timeSpanCalculator.Operate(modifier =>
                {
                    modifier.SetValue(speed, me.targetSpeed);
                });
            });
        }

        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="trigger"></param>
        protected override void OnRegisteGameLoopEvent(GameLoopTrigger trigger)
        {
            trigger.RegisteUpdate(OnUpdate, 0);
        }


        private void RecalulateTimeSpan()
        {
            float distance = Vector2.Distance(targetPos.GetValue(), currentPos.GetValue());
            float needTime = distance / speed.GetValue();
            fromPos = currentPos.GetValue();
            startTime = Time.realTimeSinceStartUp;
            targetTime = startTime + needTime;

            state = State.MOVE;
        }


        private void OnUpdate()
        {

            if (state == State.MOVE) {
                //刷新当前位置
                CalculatePos();

                if (Time.realTimeSinceStartUp > targetTime)
                {
                    Base_NofityEvent(new IE_ArriveTarget() { pos = currentPos.GetValue() });
                    state = State.STAND;
                }
            }
        }

        private void OnMoveToPos(IE_MovePos obj)
        {
            //计算目标点
            timeSpanCalculator.Operate(modifier =>
            {
                modifier.SetValue(targetPos, obj.Pos);
            });
        }
        

        /// <summary>
        /// 计算位置信息
        /// </summary>
        void CalculatePos() {
            float percent = Mathf.InverseLerp( startTime, targetTime, Time.realTimeSinceStartUp );
            Vector2 originPos = currentPos.GetValue();
            Vector2 target = Vector2.Lerp(fromPos, targetPos.GetValue(), percent);
            posControl.SetPos(target);
            currentPos.SetValue(target);           
        }
    }
}