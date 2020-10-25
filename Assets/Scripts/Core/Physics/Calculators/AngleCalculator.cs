using UnityEngine;

namespace Core.Physics.Calculators
{
    public static class AngleCalculator
    {
        public static float CalculateAngleOfAttack(Transform transform, Vector3 velocity)
        {
            if (velocity.magnitude < 1e-3)
                return 0;

            var normalizedLocalVelocity = transform.InverseTransformDirection(velocity.normalized);
            return Mathf.Atan2(-normalizedLocalVelocity.y, normalizedLocalVelocity.z) * Mathf.Rad2Deg;
        }

        public static float CalculateYawAngle(Transform transform, Vector3 velocity)
        {
            if (velocity.magnitude < 1e-3)
                return 0;

            var axis = Vector3.Cross(velocity.normalized, transform.right);
            var flatForward = Vector3.ProjectOnPlane(transform.forward, axis);
            return Vector3.SignedAngle(velocity.normalized, flatForward, axis);
        }

        public static float CalculateAngleOfIncidence(Transform transform)
        {
            return Vector3.SignedAngle(transform.forward, transform.parent.forward, transform.right);
        }
    }
}
