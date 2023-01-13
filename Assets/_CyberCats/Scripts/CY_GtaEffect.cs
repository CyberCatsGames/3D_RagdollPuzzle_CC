using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CY_GtaEffect : MonoBehaviour {
    [SerializeField] private Volume _ppVolume;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private AudioSource GtaSound;
    [SerializeField] private AudioSource BGMusic;



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
        } else {
            BGMusic.UnPause();
            Time.timeScale = 1;
            _ppVolume.enabled = false;
        }
       
    }

   
}
