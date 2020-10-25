using UnityEngine;

namespace Core.Physics.Calculators
{
    public static class ForceDirectionCalculator
    {
        public static Vector3 CalculateVerticalLiftDirection(Transform transform, Vector3 velocity)
        {
            return Vector3.Cross(velocity.normalized, transform.right).normalized;
        }

        public static Vector3 CalculateHorizontalLiftDirection(Transform transform, Vector3 velocity)
        {
            return Vector3.Cross(transform.up, velocity.normalized).normalized;
        }

        public static Vector3 CalculateLinearDragDirection(Vector3 velocity)
        {
            return -velocity.normalized;
        }

        public static Vector3 CalculateAngularDragDirection(Vector3 angularVelocity)
        {
            return -angularVelocity.normalized;
        }
    }
}
