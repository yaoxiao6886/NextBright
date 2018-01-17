using RPGBaseData;
using RPGLogicBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppetBehaviours
{
    /// <summary>
    /// 玩家类
    /// 玩家是木偶的一种， 代表所有玩家（包括主角）
    /// 责任: Facade 对外界做接口
    /// </summary>
    public class Player : Puppet
    {
        internal Player(Dictionary<DimentionEnum, DimentionalBehaviour> control) : base(control) {

        }
        

        protected override void DefineCareEvents(Eventer eventer)
        {

        }

        /// <summary>
        /// 移动接口, 移动到指定位置
        /// </summary>
        /// <param name="pos"></param>
        public void MoveTo(RPGLogicBase.Vector2 pos)
        {
            Base_NotifyEvent(new IE_MovePos() { Pos = pos });
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="eventer"></param>
        protected override void DefineGameLoopInterfaces(GameLoopTrigger trigger)
        {
            trigger.RegisteUpdate(OnUpdate);
        }

        private void OnUpdate()
        {
            
        }
    }
}
