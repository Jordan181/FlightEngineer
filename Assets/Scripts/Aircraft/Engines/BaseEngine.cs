using Aircraft.Interfaces;
using UnityEngine;

namespace Aircraft.Engines
{
    public abstract class BaseEngine : MonoBehaviour, IRespondToInput, IGenerateForce
    {
        protected float ThrottlePosition { get; private set; }

        public InputKey InputKey => InputKey.Throttle;

        public Vector3 Position => transform.position;

        public void Respond(float inputValue)
        {
            ThrottlePosition = inputValue;
        }

        public abstract Vector3 CalculateForce(AircraftState currentAircraftState);
    }
}
