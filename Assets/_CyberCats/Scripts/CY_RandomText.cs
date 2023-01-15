using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CY_RandomText : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI mudrostTMP;

    [SerializeField] private string[] Texts;


    private void OnEnable() {
       mudrostTMP.text = Texts[Random.Range(0, Texts.Length)]; 
    }

}
