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

        public void MoveLeft()
        {
            // TODO: Lerp these, instead of instantly translating.
            GameObject.transform.Translate(-1, 0, 0);
        }
    
        public void MoveRight()
        {
            GameObject.transform.Translate(1, 0, 0);
        }
        public void MoveUp()
        {
            GameObject.transform.Translate(0, 1, 0);
        }
    
        public void MoveDown()
        {
            GameObject.transform.Translate(0, -1, 0);
        }
        public void MoveForward()
        {
            GameObject.transform.Translate(0, 0, 1);
        }
    
        public void MoveBackward()
        {
            GameObject.transform.Translate(0, 0, -1);
        }
    }
}