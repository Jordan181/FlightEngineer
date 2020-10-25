using Aircraft;
using Aircraft.Interfaces;
using UnityEngine;

namespace FlightEngineer.Game
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(InputManager))]
    public class AircraftController : MonoBehaviour
    {
        [SerializeField] private Transform centreOfMass;
        private InputManager inputManager;
        private Rigidbody rigidBody;
        private IRespondToInput[] inputResponders;
        private IGenerateForce[] forceGenerators;

        public AircraftState CurrentState { get; private set; }
        
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.centerOfMass = centreOfMass.localPosition;

            inputResponders = GetComponentsInChildren<IRespondToInput>();
            forceGenerators = GetComponentsInChildren<IGenerateForce>();
        }

        private void FixedUpdate()
        {
            UpdateInputResponders();
            UpdateComponentForces();
        }

        private void UpdateInputResponders()
        {
            foreach (var inputResponder in inputResponders)
            {
                inputResponder.Respond(inputManager.CurrentInputs[inputResponder.InputKey]);
            }
        }

        private void UpdateComponentForces()
        {
            CurrentState = AircraftState.Capture(transform, rigidBody.velocity, rigidBody.angularVelocity);

            foreach (var component in forceGenerators)
            {
                rigidBody.AddForceAtPosition(component.CalculateForce(CurrentState), component.Position);
            }
        }
    }
}
