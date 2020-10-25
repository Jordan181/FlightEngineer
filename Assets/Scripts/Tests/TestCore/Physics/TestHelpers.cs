using UnityEngine;

namespace TestCore.Physics
{
    internal static class TestHelpers
    {
        public const float DefaultTolerance = 1e-5f;

        public static GameObject CreateGameObject(Quaternion rotation)
        {
            return Object.Instantiate(new GameObject(), new Vector3(0, 0), rotation);
        }
    }
}
