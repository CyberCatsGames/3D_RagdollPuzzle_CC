using UnityEngine;

namespace CodeBase.Enemies
{
    public static class TransformExtensions
    {
        public static bool EqualsByXZ(this Transform transform, Transform other)
        {
            Vector3 position = transform.position;
            Vector2 positionXZ = new(position.x, position.z);
            Vector3 otherPosition = other.position;
            Vector2 otherPositionXZ = new(otherPosition.x, otherPosition.z);
            return positionXZ == otherPositionXZ;
        }
    }
}