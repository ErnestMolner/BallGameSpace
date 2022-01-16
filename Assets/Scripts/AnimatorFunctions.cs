using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public int index;
    public bool disableOnce;

    void PlaySound(AudioClip wichSound){
        menuButtonController.audioSource.PlayOneShot (wichSound);
    }
}
