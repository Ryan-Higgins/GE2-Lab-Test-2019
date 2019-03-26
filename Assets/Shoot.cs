using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int tiberium;

    public GameObject bulletPrefab;

    public GameObject spawnPos;
    public bool atPoint = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.5f);
        if (tiberium > 0 && atPoint)
        {
            Instantiate(bulletPrefab, spawnPos.transform.position, gameObject.transform.rotation);
            tiberium -= 1;
            
        }
        StartCoroutine(Fire());
    }
}
