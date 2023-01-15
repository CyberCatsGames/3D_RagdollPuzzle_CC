using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animation anim;
    void Start() {
        anim = gameObject.GetComponent<Animation>();
        
    }

    public void PlayAnimByName(string animName) {
        anim.Play(animName);
    }
}
