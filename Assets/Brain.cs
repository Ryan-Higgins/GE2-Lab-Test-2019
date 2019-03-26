using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, gameObject.GetComponent<FollowPath>().path.waypoints[1]) <= 3)
        {
            gameObject.GetComponent<Boid>().maxSpeed = 0;
            gameObject.GetComponent<Shoot>().enabled = true;
        }
        
    }
}
