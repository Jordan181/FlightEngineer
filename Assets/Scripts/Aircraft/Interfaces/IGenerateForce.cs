using UnityEngine;

namespace Aircraft.Interfaces
{
    public interface IGenerateForce
    {
        Vector3 Position { get; }

        Vector3 CalculateForce(AircraftState currentAircraftState);
    }
}

