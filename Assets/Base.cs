using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Base : MonoBehaviour
{
    public float tiberium = 0;

    public TextMeshPro text;

    public GameObject fighterPrefab;

    public List<GameObject> paths;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tiberium());
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        text.text = "" + tiberium;

        if (tiberium >= 10)
        {
            tiberium -= 10;
            GameObject fighterSpawn = Instantiate(fighterPrefab, transform.position, fighterPrefab.transform.rotation);
            fighterSpawn.GetComponent<FollowPath>().path = paths[Random.Range(0,3)].GetComponent<Path>();
            fighterSpawn.GetComponent<Shoot>().tiberium = 7;
            fighterSpawn.GetComponent<Seek>().targetGameObject = this.gameObject;
        }
    }
    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag("bullet"))
        {
            Destroy(bullet.gameObject);
            tiberium -= 0.5f;
        }
    }

    IEnumerator Tiberium()
    {
        yield return new WaitForSeconds(1);
        tiberium += 1;
        StartCoroutine(Tiberium());
        
    }
 
}
