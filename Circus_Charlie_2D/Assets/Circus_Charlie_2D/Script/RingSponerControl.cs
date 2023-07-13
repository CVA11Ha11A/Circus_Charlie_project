using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSponerControl : MonoBehaviour
{
    public GameObject fireRing;
    

    public float sponeTime = 1f;
    public float sponeRing = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sponeRing = sponeTime * Time.deltaTime;

        if(sponeRing >= 5)
        {
            SponeFireRing();
        }
    }

    public void SponeFireRing()
    {
        sponeRing = 0;
        GameObject clone = Instantiate(fireRing, transform.position,transform.rotation);
    }
}
