using UnityEngine;

namespace AssetStore.Game_Show_Asset_Pack.Scripts
{
    public class ScrollingTexture_script : MonoBehaviour
    {
        public float ScrollX = 0.0f;
        public float ScrollY = -0.2f;

        // Update is called once per frame
        void Update()
        {
            float OffsetX = Time.time * ScrollX;
            float OffsetY = Time.time * ScrollY;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
        }
    }
}
