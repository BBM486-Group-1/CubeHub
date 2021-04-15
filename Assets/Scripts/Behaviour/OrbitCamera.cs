using UnityEngine;

namespace Behaviour
{
    // Credit: https://catlikecoding.com/unity/tutorials/movement/orbit-camera/
    [RequireComponent(typeof(Camera))]
    public class OrbitCamera : MonoBehaviour
    {
        [SerializeField] Transform focus = default;

        [SerializeField, Range(1f, 20f)] float distance = 5f;

        [SerializeField, Min(0f)] float focusRadius = 5f;

        [SerializeField, Range(0f, 1f)] float focusCentering = 0.5f;

        [SerializeField, Range(1f, 360f)] float rotationSpeed = 90f;

        [SerializeField, Range(-89f, 89f)] float minVerticalAngle = -45f, maxVerticalAngle = 45f;

        [SerializeField, Min(0f)] float alignDelay = 5f;

        [SerializeField, Range(0f, 90f)] float alignSmoothRange = 45f;

        [SerializeField] LayerMask obstructionMask = -1;

        Camera _regularCamera;

        Vector3 _focusPoint, _previousFocusPoint;

        Vector2 _orbitAngles = new Vector2(45f, 0f);

        float _lastManualRotationTime;

        void OnValidate()
        {
            if (maxVerticalAngle < minVerticalAngle)
            {
                maxVerticalAngle = minVerticalAngle;
            }
        }

        void Awake()
        {
            _regularCamera = GetComponent<Camera>();
            _focusPoint = focus.position;
            transform.localRotation = Quaternion.Euler(_orbitAngles);
        }

        void LateUpdate()
        {
            if (!PauseMenu.GameIsPaused)
            {
                UpdateFocusPoint();
                Quaternion lookRotation;
                if (ManualRotation() || AutomaticRotation())
                {
                    ConstrainAngles();
                    lookRotation = Quaternion.Euler(_orbitAngles);
                }
                else
                {
                    lookRotation = transform.localRotation;
                }

                Vector3 lookDirection = lookRotation * Vector3.forward;
                Vector3 lookPosition = _focusPoint - lookDirection * distance;

                transform.SetPositionAndRotation(lookPosition, lookRotation);
            }
        }

        void UpdateFocusPoint()
        {
            _previousFocusPoint = _focusPoint;
            Vector3 targetPoint = focus.position;
            if (focusRadius > 0f)
            {
                float distanceToTarget = Vector3.Distance(targetPoint, _focusPoint);
                float t = 1f;
                if (distanceToTarget > 0.01f && focusCentering > 0f)
                {
                    t = Mathf.Pow(1f - focusCentering, Time.unscaledDeltaTime);
                }

                if (distanceToTarget > focusRadius)
                {
                    t = Mathf.Min(t, focusRadius / distance);
                }

                _focusPoint = Vector3.Lerp(targetPoint, _focusPoint, t);
            }
            else
            {
                _focusPoint = targetPoint;
            }
        }

        bool ManualRotation()
        {
            Vector2 input = new Vector2(
                -Input.GetAxis("Mouse Y"), // Rotation on x-Axis
                Input.GetAxis("Mouse X") // Rotation on y-Axis
            );
            const float e = 0.001f;
            if (input.x < -e || input.x > e || input.y < -e || input.y > e)
            {
                _orbitAngles += rotationSpeed * Time.unscaledDeltaTime * input;
                _lastManualRotationTime = Time.unscaledTime;
                return true;
            }

            distance -= 2 * rotationSpeed * Time.unscaledDeltaTime * Input.GetAxis("Mouse ScrollWheel");

            return false;
        }

        bool AutomaticRotation()
        {
            if (Time.unscaledTime - _lastManualRotationTime < alignDelay)
            {
                return false;
            }

            Vector2 movement = new Vector2(
                _focusPoint.x - _previousFocusPoint.x,
                _focusPoint.z - _previousFocusPoint.z
            );
            float movementDeltaSqr = movement.sqrMagnitude;
            if (movementDeltaSqr < 0.0001f)
            {
                return false;
            }

            float headingAngle = GetAngle(movement / Mathf.Sqrt(movementDeltaSqr));
            float deltaAbs = Mathf.Abs(Mathf.DeltaAngle(_orbitAngles.y, headingAngle));
            float rotationChange =
                rotationSpeed * Mathf.Min(Time.unscaledDeltaTime, movementDeltaSqr);
            if (deltaAbs < alignSmoothRange)
            {
                rotationChange *= deltaAbs / alignSmoothRange;
            }
            else if (180f - deltaAbs < alignSmoothRange)
            {
                rotationChange *= (180f - deltaAbs) / alignSmoothRange;
            }

            _orbitAngles.y =
                Mathf.MoveTowardsAngle(_orbitAngles.y, headingAngle, rotationChange);
            return true;
        }

        void ConstrainAngles()
        {
            _orbitAngles.x =
                Mathf.Clamp(_orbitAngles.x, minVerticalAngle, maxVerticalAngle);

            if (_orbitAngles.y < 0f)
            {
                _orbitAngles.y += 360f;
            }
            else if (_orbitAngles.y >= 360f)
            {
                _orbitAngles.y -= 360f;
            }
        }

        static float GetAngle(Vector2 direction)
        {
            float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
            return direction.x < 0f ? 360f - angle : angle;
        }
    }
}