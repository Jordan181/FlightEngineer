using System.Text;
using Aircraft.Interfaces;
using UnityEngine;

namespace FlightEngineer.Game
{
    public class InstrumentPanel : MonoBehaviour
    {
        private static readonly Rect Location = new Rect(50, 50, 200, 200);
        private GUIStyle style;
        
        private AircraftController controller;
        private InputManager inputManager;

        public void Awake()
        {
            controller = GetComponent<AircraftController>();
            inputManager = GetComponent<InputManager>();

            style = new GUIStyle
            {
                fontSize = 20,
                fontStyle = FontStyle.Bold
            };
        }

        public void OnGUI()
        {
            GUI.Label(Location, CreateInfoString(), style);
        }

        private string CreateInfoString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Roll Input: {inputManager.CurrentInputs[InputKey.Roll]}");
            stringBuilder.AppendLine($"Pitch Input: {inputManager.CurrentInputs[InputKey.Pitch]}");
            stringBuilder.AppendLine($"Yaw Input: {inputManager.CurrentInputs[InputKey.Yaw]}");
            stringBuilder.AppendLine($"Throttle Input: {inputManager.CurrentInputs[InputKey.Throttle]:0.00}");
            stringBuilder.AppendLine($"Brakes Input: {inputManager.CurrentInputs[InputKey.Brakes]}");

            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"Angle Of Attack: {controller.CurrentState.AngleOfAttack:0.00}°");
            stringBuilder.AppendLine($"Angle Of Yaw: {controller.CurrentState.YawAngle:0.00}°");
            stringBuilder.AppendLine($"Relative Air Speed: {controller.CurrentState.RelativeAirSpeed:0.00}m/s");
            stringBuilder.AppendLine($"Altitude: {gameObject.transform.position.y:0.00}m");
            stringBuilder.AppendLine($"Rotation: {gameObject.transform.rotation.eulerAngles}°");

            return stringBuilder.ToString();
        }
    }
}