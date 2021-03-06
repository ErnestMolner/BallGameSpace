using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    [SerializeField] private List<GameObject> waypoints;
    private int listSize;
    private int index = 0;

    [SerializeField] private int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
     listSize = waypoints.Count;
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[index].transform.position) < 0.1f)
        {
            if (index >= listSize-1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * speed);
    }
}
