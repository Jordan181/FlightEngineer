using UnityEngine;

namespace Aircraft.Specifications
{
    [CreateAssetMenu(fileName = "New Propeller Spec", menuName = "Component Specifications/Propeller Spec")]
    public class PropellerSpecification : ScriptableObject
    {
        [SerializeField] private float mass;
        [SerializeField] private float diameter;
        [SerializeField] private float staticThrustCoefficient;
        [SerializeField] private AnimationCurve dynamicThrustCoefficient;
        [SerializeField] private AnimationCurve torqueCoefficient;

        public float MomentOfInertia { get; private set; }
        public float Diameter => diameter;
        public float StaticThrustCoefficient => staticThrustCoefficient;
        public AnimationCurve DynamicThrustCoefficient => dynamicThrustCoefficient;
        public AnimationCurve TorqueCoefficient => torqueCoefficient;

        private void OnValidate()
        {
            MomentOfInertia = 0.5f * mass * Mathf.Pow(0.5f * Diameter, 2);
        }
    }
}
