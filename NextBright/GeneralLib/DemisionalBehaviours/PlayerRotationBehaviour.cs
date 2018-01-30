using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGLogicBase;

namespace PuppetBehaviours
{
    class PlayerRotationBehaviour : DimentionalBehaviour
    {
        Vector2 currentDir;
        Vector2 targetDir;
        float speed = 2;
        IRotationControl rotationControl;

        public PlayerRotationBehaviour(IRotationControl rotationControl) {
            this.rotationControl = rotationControl;
        }
        

        private void OnForwardDirChanged(Vector2 orignValue, Vector2 newValue)
        {
            rotationControl.SetForwardDir(newValue);
        }

        protected override void OnRegisteEvent(Eventer eventer)
        {
            eventer.RegisteEvent<IE_PosChanged>(OnPosChanged);
        } 

        protected override void OnRegisteGameLoopEvent(GameLoopTrigger trigger)
        {
            trigger.RegisteUpdate(OnUpdate, 0);
        }

        private void OnUpdate()
        {
            if (targetDir != currentDir) {
                CalculateRot();
            }
        }

        private void CalculateRot()
        {
            currentDir = Vector2.SmoothTo(currentDir, targetDir, speed, Time.deltaTime);
            rotationControl.SetForwardDir(currentDir);
        }

        private void OnPosChanged(IE_PosChanged obj)
        {
            Vector2 forwardVec = obj.pos - obj.originPos;
            
            targetDir = forwardVec;
        }
    }
}
