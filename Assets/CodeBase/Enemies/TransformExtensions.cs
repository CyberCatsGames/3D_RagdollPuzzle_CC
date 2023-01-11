using UnityEngine;

namespace CodeBase.Enemies
{
    public static class TransformExtensions
    {
        public static bool EqualsByXZRoundInt(this Transform transform, Transform other)
        {
            Vector3 position = transform.position;
            Vector2 positionXZ = new((int)position.x, (int)position.z);
            Vector3 otherPosition = other.position;
            Vector2 otherPositionXZ = new((int)otherPosition.x, (int)otherPosition.z);
            return positionXZ == otherPositionXZ;
        }
    }
}