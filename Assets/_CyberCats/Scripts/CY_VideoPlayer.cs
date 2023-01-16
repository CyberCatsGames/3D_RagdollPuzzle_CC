using System;
using Animations;
using ARP.APR.Scripts;
using CodeBase.Enemies;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class CY_VideoPlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject _bG_Url;
    [SerializeField] private GameObject _bG_Gif;

    public UnityEvent FinishEvent;
    private bool _isPlaying;
    public bool DefaultUrl = true;

    public VideoClip[] clips;
    private EnemyAnimator[] _enemies;


    private void Start()
    {
        _enemies = FindObjectsOfType<EnemyAnimator>();

        Invoke(nameof(TurnOn), 1f);
    }

    private void TurnOn()
    {
        foreach (EnemyAnimator enemyAnimator in _enemies)
        {
            enemyAnimator.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (!DefaultUrl)
        {
            _videoPlayer.clip = clips[Random.Range(0, clips.Length - 1)];
        }

        _videoPlayer.loopPointReached += EndReached;
    }

    private void Update()
    {
        if (!_isPlaying)
        {
            if (_videoPlayer.isPrepared)
            {
                ShowVideo();
                _bG_Url.SetActive(true);
                _bG_Gif.SetActive(false);
            }
            else
            {
                _bG_Url.SetActive(false);
                _bG_Gif.SetActive(true);
            }
        }
    }

    private void ShowVideo()
    {
        foreach (var VARIABLE in _enemies)
        {
            VARIABLE.gameObject.SetActive(false);
        }

        FindObjectOfType<Naruto>().GetComponentInChildren<APRController>().useControls = false;

        _isPlaying = true;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        FinishEvent?.Invoke();

        foreach (var VARIABLE in _enemies)
        {
            VARIABLE.gameObject.SetActive(true);
        }

        FindObjectOfType<Naruto>().GetComponentInChildren<APRController>().useControls = true;
        _isPlaying = false;
        Invoke(nameof(TurnOn), 1f);
    }
}