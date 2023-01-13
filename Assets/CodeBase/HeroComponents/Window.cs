using System;
using CodeBase.Logic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.HeroComponents
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Window : MonoBehaviour
    {
        [SerializeField] private Button _first;
        [SerializeField] private Button _second;

        [SerializeField] private float _duration = 1f;

        private CanvasGroup _canvasGroup;
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _first.onClick.AddListener(RestartLevel);
            _second.onClick.AddListener(RestartLevel);
        }

        private void OnDisable()
        {
            _first.onClick.RemoveListener(RestartLevel);
            _second.onClick.RemoveListener(RestartLevel);
        }

        private void RestartLevel()
        {
            _sceneLoader.Load(SceneManager.GetActiveScene().name);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, _duration);
        }

        public void Hide()
        {
            _canvasGroup.DOFade(0f, _duration)
                .OnComplete(() => _canvasGroup.gameObject.SetActive(false));
        }
    }
}