using System;
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

        private Vector3 SnapToNearestAxis(Vector3 direction)
        {
            float x = Math.Abs(direction.x);
            float y = Math.Abs(direction.y);
            float z = Math.Abs(direction.z);
            if (x > y && x > z){
                return new Vector3(Math.Sign(direction.x),0,0);
            } else if (y > x && y > z){
                return new Vector3(0,Math.Sign(direction.y),0);
            } else {
                return new Vector3(0,0,Math.Sign(direction.z));
            }
        }

        public virtual void MoveLeft()
        {
            var camera = Camera.main;

            if (!(camera is null))
            {
                var cameraTransform = camera.transform; 
                var right = cameraTransform.right; 

                right = SnapToNearestAxis(right);
            
                GameObject.transform.Translate(-right);
            }
        }
    
        public virtual void MoveRight()
        {
            var camera = Camera.main;

            if (!(camera is null))
            {
                var cameraTransform = camera.transform; 
                var right = cameraTransform.right; 

                right = SnapToNearestAxis(right);
            
                GameObject.transform.Translate(right);
            }
        }
        public virtual void MoveUp()
        {
            var camera = Camera.main;

            if (!(camera is null))
            {
                var cameraTransform = camera.transform; 
                var up = cameraTransform.up; 

                up = SnapToNearestAxis(up);
            
                GameObject.transform.Translate(up);
            }
        }
    
        public virtual void MoveDown()
        {
            var camera = Camera.main;

            if (!(camera is null))
            {
                var cameraTransform = camera.transform; 
                var up = cameraTransform.up; 

                up = SnapToNearestAxis(up);
            
                GameObject.transform.Translate(-up);
            }
        }
        public virtual void MoveForward()
        {
            var camera = Camera.main;

            if (!(camera is null))
            {
                var cameraTransform = camera.transform;
                var forward = cameraTransform.forward; 

                forward = SnapToNearestAxis(forward);
            
                GameObject.transform.Translate( forward);
            }
        }
    
        public virtual void MoveBackward()
        {
            var camera = Camera.main;

            if (!(camera is null))
            {
                var cameraTransform = camera.transform;
                var forward = cameraTransform.forward; 
                forward = SnapToNearestAxis(forward);
            
                GameObject.transform.Translate(-forward);
            }
        }
    }
}
