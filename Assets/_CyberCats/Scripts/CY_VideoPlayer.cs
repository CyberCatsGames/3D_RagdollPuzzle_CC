using System;
using System.Collections.Generic;
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
        _isPlaying = true;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        FinishEvent?.Invoke();

        foreach (var VARIABLE in FindObjectsOfType<EnemyAttack>())
        {
            VARIABLE.gameObject.SetActive(true);
        }
    }
}