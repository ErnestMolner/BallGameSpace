using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    private Rigidbody rb ;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    bool isOnGround;

    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Jump Signal
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }

    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        direction = Quaternion.AngleAxis(camera.rotation.eulerAngles.y, Vector3.up) * direction;

        rb.AddForce(direction * speed);
    }

    private void Jump() 
    {
        rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
    }

    private void OnApplicationFocus(bool focus) 
    {
        if (focus) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnCollisionStay(){
        isOnGround = true;
    }
}
