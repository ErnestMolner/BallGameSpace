using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorContoller : MonoBehaviour
{
    [SerializeField] private Animator Door1 = null;
    [SerializeField] private Animator Door2 = null;
    [SerializeField] private bool IsOpen = false;
    [SerializeField] private AudioSource DoorCloseAudio;
    [SerializeField] private AudioSource Celevration;
    public UnityEvent onEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsOpen)
            {
                Debug.Log("EneredColider");
                DoorCloseAudio.Play();
                Door1.Play("DoorClose");
                Door2.Play("DoorClose");
                GetComponent<Collider>().enabled = false;
                onEntered.Invoke();
            }
            else
            {
                Debug.Log("EneredColider");
                DoorCloseAudio.Play();
                Celevration.Play();
                Door1.Play("DoorOpen");
                Door2.Play("DoorOpen");
                GetComponent<Collider>().enabled = false;
            }
        }
    }

}
