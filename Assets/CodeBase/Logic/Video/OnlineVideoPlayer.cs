using UnityEngine;
using UnityEngine.Video;

namespace CodeBase.Logic.Video
{
    public class OnlineVideoPlayer : MonoBehaviour
    {
        [SerializeField] private string _url;

        private VideoPlayer _videoPlayer;

        private void Awake()
        {
            _videoPlayer = GetComponent<VideoPlayer>();
        }

        private void Start()
        {
            Color color = new Color(0.58f, 1f, 0.33f);
            _videoPlayer.url = _url;
            _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            _videoPlayer.EnableAudioTrack(0, true);
            _videoPlayer.Prepare();
        }
    }
}