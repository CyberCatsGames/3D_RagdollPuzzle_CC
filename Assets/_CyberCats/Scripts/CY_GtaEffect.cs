using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CY_GtaEffect : MonoBehaviour {
    [SerializeField] private Volume _ppVolume;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private AudioSource GtaSound;
    [SerializeField] private AudioSource BGMusic;
    [SerializeField] private GameObject LosePopUp;
    [SerializeField] private float _duration;



    private void OnEnable() {
        GtaEffect(true);
    }
    private void OnDisable() {
        GtaEffect(false);
    }

    public void GtaEffect(bool isOn) {
        Debug.Log("GTA EFFECT");
        if (isOn) {
            BGMusic.Pause();
            GtaSound.Play();

            Time.timeScale = _timeSpeed;
            _ppVolume.enabled = true;

            StartCoroutine(ShowLosePopUp());
        } else {
            BGMusic.UnPause();
            Time.timeScale = 1;
            _ppVolume.enabled = false;
        }
       
    }

    private IEnumerator ShowLosePopUp() {
        yield return new WaitForSecondsRealtime(_duration);
        LosePopUp.SetActive(true);
        gameObject.SetActive(false);
    }

   
}
