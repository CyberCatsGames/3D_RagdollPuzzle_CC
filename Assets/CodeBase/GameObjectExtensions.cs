using UnityEngine;

namespace CodeBase
{
    public static class GameObjectExtensions
    {
        public static bool IsInLayer(this GameObject gameObject, LayerMask layer)
        {
            return (layer.value & (1 << gameObject.layer)) != 0;
        }
    }
}