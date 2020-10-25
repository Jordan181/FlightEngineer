using UnityEngine;

namespace Aircraft.Specifications
{
    [CreateAssetMenu(fileName = "New Piston Engine Spec", menuName = "Component Specifications/Piston Engine Spec")]
    public class PistonEngineSpecification : ScriptableObject
    {
        [SerializeField] private float minRpm;
        [SerializeField] private float minTorque;
        [SerializeField] private float maxRpm;
        [SerializeField] private float maxTorque;
        [SerializeField] private AnimationCurve normalizedTorqueCurve;

        public float MinRpm
        {
            get => minRpm;
            set => minRpm = value;
        }

        public float MinTorque
        {
            get => minTorque;
            set => minTorque = value;
        }

        public float MaxRpm
        {
            get => maxRpm;
            set => maxRpm = value;
        }

        public float MaxTorque
        {
            get => maxTorque;
            set => maxTorque = value;
        }

        public AnimationCurve NormalizedTorqueCurve
        {
            get => normalizedTorqueCurve;
            set => normalizedTorqueCurve = value;
        }
    }
}
