using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingControl : MonoBehaviour
{
    public Rigidbody2D fireRing;
    public 

    //public float ringSpeed = 10f;



    // Start is called before the first frame update
    void Start()
    {
        fireRing = GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {

        fireRing.transform.Translate(Vector2.left * ringSpeed * Time.deltaTime);

        if(fireRing.transform == )
     


    }
}
