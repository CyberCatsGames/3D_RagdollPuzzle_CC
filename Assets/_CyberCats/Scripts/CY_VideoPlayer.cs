
using UnityEngine;
using UnityEngine.Video;

public class CY_VideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _bG_Url;
    [SerializeField] private GameObject _bG_Gif;
    private bool _isPlaying;

    private void Update() {
        if (!_isPlaying) {
            if (_videoPlayer.isPrepared) {
                ShowVideo();
                _bG_Url.SetActive(true);
                _bG_Gif.SetActive(false);
            } else {
                _bG_Url.SetActive(false);
                _bG_Gif.SetActive(true);
            }
        }
    }

    private void ShowVideo() {
        _isPlaying = true;
    }
}
