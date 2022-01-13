using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public bool disableOnce;

    void PlaySound(AudioClip wichSound){
        //if(!disableOnce){
            menuButtonController.audioSource.PlayOneShot (wichSound);
        //}else{
        //    disableOnce = false;
        //}
    }
}
