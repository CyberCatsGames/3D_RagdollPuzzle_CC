using UnityEngine;
using UnityEngine.Video;

namespace CodeBase.Enemies
{
    public class PlayDisclaimerOrNot : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private GameObject _urlVidepPlayer;

        private void Awake()
        {
            if (CurrentSceneManager.Instance.Level > 0)
            {
                _urlVidepPlayer.gameObject.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                _videoPlayer.Play();
            }
        }
    }
}