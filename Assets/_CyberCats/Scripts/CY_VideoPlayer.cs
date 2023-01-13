
using UnityEngine;
using UnityEngine.Video;

public class CY_VideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _bG_Url;
    private bool _isPlaying;

    private void Update() {
        if (!_isPlaying) {
            if (_videoPlayer.isPrepared) {
                ShowVideo();
                _bG_Url.SetActive(true);
            } else {
                _bG_Url.SetActive(false);
            }
        }
    }

    private void ShowVideo() {
        Debug.Log("Show Video");
        _isPlaying = true;
    }
}
