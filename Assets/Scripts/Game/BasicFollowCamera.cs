using UnityEngine;

namespace FlightEngineer.Game
{
    public class BasicFollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float distance;
        [SerializeField] private float height;
        [SerializeField] private float smoothSpeed;
        [SerializeField] private float minHeightFromGround;

        private Vector3 smoothVelocity;

        void FixedUpdate()
        {
            var wantedHeight = height;

            var distanceToGround = GetDistanceFromGround(transform.position);
            if (distanceToGround < minHeightFromGround)
            {
                wantedHeight = height + (minHeightFromGround - distanceToGround);
            }
            
            var wantedCameraPosition = target.position + (-target.forward * distance) + (Vector3.up * wantedHeight);
        
            transform.position = Vector3.SmoothDamp(transform.position, wantedCameraPosition, ref smoothVelocity, smoothSpeed);
            transform.LookAt(target);
        }

        private static float GetDistanceFromGround(Vector3 componentPosition)
        {
            if (Physics.Raycast(componentPosition, Vector3.down, out var hit))
            {
                if (hit.transform.tag == "Ground")
                {
                    return hit.distance;
                }
            }

            return float.PositiveInfinity;
        }
    }
}
