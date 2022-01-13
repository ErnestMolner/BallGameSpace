using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pyhsicsButton1 : MonoBehaviour
{

    public Rigidbody buttonTopRigid;
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public AudioSource pressedSound;
    public AudioSource releasedSound;
    public Collider[] CollidersToIgnore;

    public GameObject door;
    public GameObject door2;
   /* public Transform door;

    public Vector3 closedPosition = new Vector3(.51f, 3.63f, 0);
    public Vector3 openedPosition = new Vector3(.51f, 7f, 0);
    
    */
   // public float openSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {

        Collider localCollider = GetComponent<Collider>();
        if (localCollider != null)
        {
            Physics.IgnoreCollision(localCollider, buttonTop.GetComponentInChildren<Collider>());

            foreach (Collider singleCollider in CollidersToIgnore)
            {
                Physics.IgnoreCollision(localCollider, singleCollider);
            }
        }

        if (transform.eulerAngles != Vector3.zero)
        {
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        }
        else
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = door.GetComponent<Animator>();
        Animator anim2 = door2.GetComponent<Animator>();
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else
            buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);


        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
            isPressed = true;
        else
            isPressed = false;

        if (isPressed && prevPressedState != isPressed)
        {

            // door.position = Vector3.Lerp(door.position, openedPosition, Time.deltaTime * openSpeed);
            anim.SetBool("IsOpen", true);
            anim2.SetBool("IsOpen", true);
            Debug.Log("button pressed");
        }
            
        if (!isPressed && prevPressedState != isPressed)
        {
            anim.SetBool("IsOpen", false);
            anim2.SetBool("IsOpen", false);
            //door.position = Vector3.Lerp(door.position, closedPosition, Time.deltaTime * openSpeed);
            Debug.Log("button released");
        }
            
    }

}
