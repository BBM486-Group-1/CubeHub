using Domain;
using UnityEngine;

namespace Behaviour
{
    public class FlyCamera : MonoBehaviour, IMovable
    {
        /**
     * Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.
     * Converted to C# 27-02-13 - no credit wanted.
     * Added resetRotation, RF control, improved initial mouse position, 2015-03-11 - Roi Danton.
     * Remaded camera rotation - now cursor is locked, added "Walker Mode", 25-09-15 - LookForward.
     * Simple flycam I made, since I couldn't find any others made public.
     * Made simple to use (drag and drop, done) for regular keyboard layout
     * wasdrf : Basic movement
     * shift : Makes camera accelerate
     * space : Moves camera on X and Z axis only.  So camera doesn't gain any height
     * q : Change mode
     */
        public float mouseSensitivity = 5.0f; // Mouse rotation sensitivity.

        public float speed = 10.0f; // Regular speed. 
        public float shiftAdd = 25.0f; // Multiplied by how long shift is held.  Basically running.
        public float maxShift = 100.0f; // Maximum speed when holding shift. 

        private float totalRun = 1.0f;
        private float rotationY = 0.0f;
        private float maximumY = 90.0f; // Not recommended to change
        private float minimumY = -90.0f; // these parameters. 

        private bool _moveForward;
        private bool _moveBackward;
        private bool _moveLeft;
        private bool _moveRight;
        private bool _moveUp;
        private bool _moveDown;

        void Start()
        {
            // Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
        }

        void FixedUpdate()
        {
            // Mouse commands.
            var rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0.0f);

            // Keyboard commands.
            Vector3 p = GetDirection();
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1.0f, 1000.0f);
            p = p * speed;

            p = p * Time.deltaTime;
            transform.Translate(p);

            ResetInput();
        }

        private Vector3 GetDirection()
        {
            Vector3 pVelocity = new Vector3(_moveRight ? 1 : _moveLeft ? -1 : 0, 0.0f,
                _moveForward ? 1 : _moveBackward ? -1 : 0);
            // Strife
            if (_moveDown)
            {
                pVelocity += new Vector3(0.0f, -1.0f, 0.0f);
            }

            if (_moveUp)
            {
                pVelocity += new Vector3(0.0f, 1.0f, 0.0f);
            }

            return pVelocity;
        }


        public void ResetInput()
        {
            _moveForward = false;
            _moveBackward = false;
            _moveLeft = false;
            _moveRight = false;
            _moveUp = false;
            _moveDown = false;
        }

        public void ResetRotation(Vector3 lookAt)
        {
            transform.LookAt(lookAt);
        }

        public void MoveUp()
        {
            _moveUp = true;
        }

        public void MoveDown()
        {
            _moveDown = true;
        }

        public void MoveLeft()
        {
            _moveLeft = true;
        }

        public void MoveRight()
        {
            _moveRight = true;
        }

        public void MoveForward()
        {
            _moveForward = true;
        }

        public void MoveBackward()
        {
            _moveBackward = true;
        }
    }
}