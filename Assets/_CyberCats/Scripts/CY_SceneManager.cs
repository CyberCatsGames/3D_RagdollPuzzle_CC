using CodeBase.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CY_SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _titleScenePanel;
    [SerializeField] private GameObject _curtain;
    [SerializeField] private AudioSource _bgMusic;

    private void Awake()
    {
        // if (PlayerPrefs.GetInt("LoadTimes") == 0)
        // {
            _titleScenePanel.gameObject.SetActive(true);
        // }
        // else
        // {
        //     _titleScenePanel.gameObject.SetActive(false);
        //     _curtain.gameObject.SetActive(true);
        //     _bgMusic.Play();
        // }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        PlayerPrefs.SetInt("LoadTimes", 1);
        SceneLoader.Instance.Load(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LoadTimes", 0);
    }
}