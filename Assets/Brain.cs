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
            gameObject.GetComponent<FollowPath>().enabled = false;
            gameObject.GetComponent<Shoot>().enabled = true;
            gameObject.GetComponent<Shoot>().atPoint = true;
        }

        if (gameObject.GetComponent<Shoot>().tiberium <= 0)
        {
            gameObject.GetComponent<Shoot>().enabled = false;
            gameObject.GetComponent<Boid>().maxSpeed = 5;
            gameObject.GetComponent<Seek>().enabled = true;
            gameObject.GetComponent<Shoot>().atPoint = false;
        }

        if (Vector3.Distance(gameObject.transform.position, gameObject.GetComponent<Seek>().targetGameObject.transform.position) <= 2 && gameObject.GetComponent<Seek>().enabled == true)
        {
            gameObject.GetComponent<Boid>().maxSpeed = 0;
            if (gameObject.GetComponent<Seek>().targetGameObject.GetComponent<Base>().tiberium >= 7)
            {
                gameObject.GetComponent<Seek>().targetGameObject.GetComponent<Base>().tiberium -= 7;
                gameObject.GetComponent<Shoot>().tiberium = 7;
                gameObject.GetComponent<Seek>().enabled = false;
                gameObject.GetComponent<FollowPath>().enabled = true;
                gameObject.GetComponent<FollowPath>().path.next = 0;
                gameObject.GetComponent<Boid>().maxSpeed = 5;
            }
        }
    }
}
