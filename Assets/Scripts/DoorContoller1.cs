using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorContoller1 : MonoBehaviour
{

    public UnityEvent onEntered;
    [SerializeField] private bool IsOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsOpen)
            {

                GetComponent<Collider>().enabled = false;
                onEntered.Invoke();
            }
        }
    }

}
