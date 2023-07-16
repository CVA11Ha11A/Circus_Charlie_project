using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSponerControl : MonoBehaviour
{
    public GameObject fireRing;
    GameObject clone;
    private int randSpone = 0; 
    public float sponeTime = 1f;
    public float sponeRing = 0f;

    // Start is called before the first frame update
    void Start()
    {
        randSpone = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        sponeRing += sponeTime * Time.deltaTime;

        if(sponeRing >= randSpone)
        {
            SponeFireRing();
        }
    }

    public void SponeFireRing()
    {
        sponeRing = 0;
        randSpone = Random.Range(0, 10);
        clone = Instantiate(fireRing, transform.position,transform.rotation);
    }


}
