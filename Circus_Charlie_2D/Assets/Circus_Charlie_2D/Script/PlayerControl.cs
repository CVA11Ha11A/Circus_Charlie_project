using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D player;

    public Animator chalriAni;
    public Animator lionAni;
    public float playerSpeed = 5.0f;

    private bool charlriMoveBool = false;
    private bool charlriJumpBool = false;



    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody2D>();

        chalriAni.GetComponent<Animator>();
        lionAni.GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {

        //float xMove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

        // 플레이어 이동

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
        { 
            float h = Input.GetAxis("Horizontal");
            player.transform.Translate(Vector2.right * h * playerSpeed * Time.deltaTime);
            charlriMoveBool = true;

            //player.AddForce(Vector2.right * h * playerSpeed * Time.deltaTime );
            if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                charlriMoveBool = false;
            }
        }
        
        chalriAni.SetBool("Charli_Run",charlriMoveBool); 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(charlriJumpBool == true && gameObject.CompareTag("UnderBox"))
        { 
            charlriMoveBool = false;
        }
    }
}
