using CodeBase.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CY_SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _titleScenePanel;
    [SerializeField] private GameObject _curtain;
    private void Awake() {
        if (PlayerPrefs.GetInt("LoadTimes") == 0) {
            _titleScenePanel.gameObject.SetActive(true);
        } else {
            _titleScenePanel.gameObject.SetActive(false);
            _curtain.gameObject.SetActive(true);

        }
    }
    
    public void Update() {
        if(Input.GetKeyDown(KeyCode.L)) {
            ReloadScene();
        }
    }
    public void ReloadScene() {
        PlayerPrefs.SetInt("LoadTimes", 1);
        SceneLoader.Instance.Load("Winter");

    }
    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("LoadTimes", 0);
    }
}
