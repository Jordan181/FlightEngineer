using Aircraft.Interfaces;
using Aircraft.Specifications;
using UnityEngine;

namespace Aircraft.Wheels
{
    public abstract class BaseWheel : MonoBehaviour, IRespondToInput
    {
        [SerializeField] private WheelSpecification wheelSpec;
        [SerializeField] private Transform wheelGraphic;

        protected WheelCollider WheelCollider { get; private set; }

        protected WheelSpecification WheelSpec => wheelSpec;

        public abstract InputKey InputKey { get; }

        private void Awake()
        {
            WheelCollider = GetComponent<WheelCollider>();
            WheelCollider.motorTorque = 0.000000001f;
        }

        private void FixedUpdate()
        {
            WheelCollider.GetWorldPose(out var worldPosition, out var worldRotation);
            wheelGraphic.position = worldPosition;
            wheelGraphic.rotation = worldRotation;
        }

        public abstract void Respond(float inputValue);
    }
}
