using UnityEngine;

namespace Domain
{
    public abstract class AbstractMovable : IMovable
    {
        protected readonly GameObject GameObject;

        protected AbstractMovable(GameObject gameObject)
        {
            GameObject = gameObject;
        }
        
        public void SetPosition(Vector3 position)
        {
            GameObject.transform.position = position;
        }

        public Vector3 GetPosition()
        {
            return GameObject.transform.position;
        }

        public virtual void MoveLeft()
        {
            // TODO: Lerp these, instead of instantly translating.
            GameObject.transform.Translate(-1, 0, 0);
        }
    
        public virtual void MoveRight()
        {
            GameObject.transform.Translate(1, 0, 0);
        }
        public virtual void MoveUp()
        {
            GameObject.transform.Translate(0, 1, 0);
        }
    
        public virtual void MoveDown()
        {
            GameObject.transform.Translate(0, -1, 0);
        }
        public virtual void MoveForward()
        {
            GameObject.transform.Translate(0, 0, 1);
        }
    
        public virtual void MoveBackward()
        {
            GameObject.transform.Translate(0, 0, -1);
        }
    }
}