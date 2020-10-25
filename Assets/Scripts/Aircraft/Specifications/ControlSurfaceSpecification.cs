using Aircraft.Interfaces;
using UnityEngine;

namespace Aircraft.Specifications
{
    [CreateAssetMenu(fileName = "New Control Surface Spec", menuName = "Component Specifications/Control Surface Spec")]
    public class ControlSurfaceSpecification : ScriptableObject
    {
        [SerializeField] private float surfaceArea;
        [SerializeField] private float maxAngle;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Vector3 localRotationAxis;
        [SerializeField] private Vector3 surfaceNormal;
        [SerializeField] private InputKey inputKey;

        public float SurfaceArea => surfaceArea;
        public float MaxAngle => maxAngle;
        public float RotationSpeed => rotationSpeed;
        public Vector3 LocalRotationAxis => localRotationAxis;
        public Vector3 SurfaceNormal => surfaceNormal;
        public InputKey InputKey => inputKey;
    }
}
