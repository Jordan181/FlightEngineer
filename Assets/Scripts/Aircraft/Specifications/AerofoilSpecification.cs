using Core.Physics;
using Core.Physics.Dynamics;
using UnityEngine;

namespace Aircraft.Specifications
{
    [CreateAssetMenu(fileName = "New Aerofoil Spec", menuName = "Component Specifications/Aerofoil Spec")]
    public class AerofoilSpecification : ScriptableObject
    {
        [SerializeField] private Mesh mesh;
        [SerializeField] private float chordLength;
        [SerializeField] private float span;
        [SerializeField] private AnimationCurve liftCoefficientCurve;
        [SerializeField] private AnimationCurve dragCoefficientCurve;

        private Keyframe liftCurveMin;
        private Keyframe liftCurveMax;
                   
        private Keyframe dragCurveMin;
        private Keyframe dragCurveMax;

        public Mesh Mesh => mesh;
        public float ChordLength => chordLength;
        public float Span => span;

        private void OnValidate()
        {
            liftCurveMin = liftCoefficientCurve[0];
            liftCurveMax = liftCoefficientCurve[liftCoefficientCurve.length - 1];

            dragCurveMin = dragCoefficientCurve[0];
            dragCurveMax = dragCoefficientCurve[dragCoefficientCurve.length - 1];
        }
        
        public float GetLiftCoefficient(float angleOfAttack)
        {
            if (angleOfAttack < liftCurveMin.time)
            {
                var proportion = Mathf.InverseLerp(liftCurveMin.time, -90, angleOfAttack);
                return Mathf.Lerp(liftCurveMin.value, 0, proportion);
            }
            if (angleOfAttack > liftCurveMax.time)
            {
                var proportion = Mathf.InverseLerp(liftCurveMax.time, 90, angleOfAttack);
                return Mathf.Lerp(liftCurveMax.value, 0, proportion);
            }

            return liftCoefficientCurve.Evaluate(angleOfAttack);
        }

        public float GetDragCoefficient(float angleOfAttack)
        {
            if (angleOfAttack < dragCurveMin.time)
            {
                var proportion = Mathf.InverseLerp(dragCurveMin.time, -90, angleOfAttack);
                return Mathf.Lerp(dragCurveMin.value, Aerodynamics.FlatPlateDragCoefficient, proportion);
            }
            if (angleOfAttack > dragCurveMax.time)
            {
                var proportion = Mathf.InverseLerp(dragCurveMax.time, 90, angleOfAttack);
                return Mathf.Lerp(dragCurveMax.value, Aerodynamics.FlatPlateDragCoefficient, proportion);
            }

            return dragCoefficientCurve.Evaluate(angleOfAttack);
        }
    }
}