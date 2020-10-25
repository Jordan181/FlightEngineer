using System;
using System.Collections.Generic;
using Aircraft.Interfaces;
using UnityEngine;

namespace FlightEngineer.Game
{
    public class InputManager : MonoBehaviour
    {
        private float lastThrottle;

        public Dictionary<InputKey, float> CurrentInputs { get; }

        public InputManager()
        {
            CurrentInputs = new Dictionary<InputKey, float>();
        }

        public void FixedUpdate()
        {
            CurrentInputs[InputKey.Roll] = Input.GetAxisRaw("Horizontal");
            CurrentInputs[InputKey.Pitch] = Input.GetAxisRaw("Vertical");
            CurrentInputs[InputKey.Yaw] = Input.GetAxisRaw("Yaw");
            CurrentInputs[InputKey.Brakes] = Convert.ToSingle(Input.GetButton("Brake"));

            var throttle = Input.GetAxis("ThrottleUp") - Input.GetAxis("ThrottleDown");
            throttle = Mathf.Clamp01(throttle/100 + lastThrottle);
            lastThrottle = throttle;

            CurrentInputs[InputKey.Throttle] = throttle;
        }
    }
}
