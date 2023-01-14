using DG.Tweening;
using UnityEngine;

namespace _CyberCats.Scenes.Scripts
{
    public class ShowObstacle : MonoBehaviour
    {
        [SerializeField] private float _duration = 4f;
        
        private Vector3 _finishScale;

        private void Awake()
        {
            _finishScale = transform.localScale;
            transform.localScale /= 2;
        }

        private void Start()
        {
            transform.DOScale(_finishScale, _duration)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}