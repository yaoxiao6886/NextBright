using RPGLogicBase;

namespace PuppetBehaviours
{
    public interface IRotationControl
    {
        void SetForwardDir(Vector2 dir);
        Vector2 GetForwardDir();
    }
}