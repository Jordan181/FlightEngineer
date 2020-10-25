using UnityEngine;

namespace Aircraft.Specifications
{
    [CreateAssetMenu(fileName = "New BaseWheel Spec", menuName = "Component Specifications/BaseWheel Spec")]
    public class WheelSpecification : ScriptableObject
    {
        [SerializeField] private float maximumBrakingForce;
        [SerializeField] private float maximumSteeringAngle;

        public float MaximumBrakingForce => maximumBrakingForce;

        public float MaximumSteeringAngle => maximumSteeringAngle;
    }
}
