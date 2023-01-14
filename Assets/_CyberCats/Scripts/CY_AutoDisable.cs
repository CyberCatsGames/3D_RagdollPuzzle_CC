using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class CY_AutoDisable : MonoBehaviour
{
    public string TriggerName;
    public Animator DamageAnim;
    public void Damage() {
        DamageAnim.SetTrigger(TriggerName);
    }

}
