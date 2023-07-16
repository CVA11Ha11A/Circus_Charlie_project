using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerObj;

    private Rigidbody2D playerRigid;
    private Collider2D playerCollider;

    public Collider2D underBox;
    public GameObject firering;
    public GameObject fireringSponer;
    public GameObject backgroundPeople01;
    public GameObject backgroundPeople02;

    AudioSource charlieAudioSource;

    public AudioClip jumpSound;
    public AudioClip dieSound;



    public Animator chalriAni;

    public float playerSpeed = 5.0f;


    private int playerLife = 3;
    private bool charlieMoveBool = false;
    private bool charlieJumpBool = false;
    private bool charlieIsJump = false;
    private bool backgroundPeoples = false;
        

    //애니메이션 Any State 로 사용할때에 bool 형식으로 사용시
    //조건문이 많아져서 Triger로 변경
    //private bool isgole = false;

    //죽을때 플레이어가 입력해도 못움직이게 하기위한 bool
    private bool playerInputLock = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = playerObj.GetComponent<Rigidbody2D>();
        playerCollider = playerObj.GetComponent<Collider2D>();
        underBox.GetComponent<Collider2D>();

        chalriAni.GetComponent<Animator>();

        firering.GetComponent<GameObject>();
        fireringSponer.GetComponent<GameObject>();
        backgroundPeople01.GetComponent<GameObject>();
        backgroundPeople02.GetComponent<GameObject>();

        charlieAudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
 

        //float xMove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

        // 플레이어 이동

        //유저가 키 입력하면 들어갈 함수
        if (Input.anyKey)
        {
            UserInput();
        }

        //유저가 키 입력을 하지 않았을때 들어갈 함수
        if (Input.anyKey == false)
        {
            UserNotInput();
        }



        chalriAni.SetBool("Charlie_Run", charlieMoveBool);
        chalriAni.SetBool("Charlie_Jump", charlieJumpBool);
        
    }

    public void UserInput()
    {
        if (playerInputLock == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                float x = Input.GetAxis("Horizontal");
                playerRigid.transform.Translate(Vector2.right * x * playerSpeed * Time.deltaTime);
                charlieMoveBool = true;


            }

            //스페이스바 누르면 점프
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (charlieIsJump == false)
                {
                    charlieJumpBool = true;
                    charlieIsJump = true;
                    float y = Input.GetAxis("Vertical");
                    playerRigid.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
                    charlieAudioSource.clip = jumpSound;
                    charlieAudioSource.Play();
                }
            }

        }

    }
    public void UserNotInput()
    {
        charlieMoveBool = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (underBox.CompareTag("UnderBox"))
        {
            charlieIsJump = false;
            charlieJumpBool = false;
        }

        if (collision.gameObject.CompareTag("GolePoint"))
        {
            //Clear Bool 
            //isgole = true;
            //chalriAni.SetBool("Charlie_Clear", true);
            //Invoke("ClearAniDelayFalseTest", 0.1f);
            ////Clear Bool

            //골인 하면 움직일수 있는 적 오브젝트 삭제
            Destroy(fireringSponer);
            
            Destroy(firering);
           




            chalriAni.SetTrigger("Charlie_ClearTr");

            playerInputLock = true;





            for (int i = 0; i < 20; i++)
            {
                //Debug.LogFormat("몇번째 돌고 있는지 : {0}", i);
                Invoke("ClearBackground", 0.5f * i);

            }



        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Debug.Log("적이랑 부딪힘");

            playerInputLock = true;
            chalriAni.SetTrigger("Charlie_Die");

            charlieAudioSource.clip = dieSound;
            charlieAudioSource.Play();
            GameManager.instance.stage01_ThemeOff = 1;


            Invoke("PlayerFall", 1f);

            playerLife -= 1;

            //이다음에 다시 시작하는 무언가를 만들어야 할듯

        }

    }

    private void PlayerFall()
    {
        playerCollider.isTrigger = true;
    }

    private void ClearBackground()
    {
        //Debug.LogFormat("몇번째 돌고 있는지");
        if (backgroundPeoples == true)
        {
            //Debug.LogFormat("꺼졌다");
            backgroundPeoples = false;
            backgroundPeople01.SetActive(false);
            backgroundPeople02.SetActive(false);

        }

        else if (backgroundPeoples == false)
        {
            //Debug.LogFormat("켜졌다");
            //Enable
            backgroundPeoples = true;
            backgroundPeople01.SetActive(true);
            backgroundPeople02.SetActive(true);            
            //async

        }


    }


    //player.AddForce(Vector2.right * h * playerSpeed * Time.deltaTime );

    //아래의 조건문으로 Move false 를 했을떄에 인식이 잘 안되는듯
    //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
    //{
    //    charlriMoveBool = false;
    //}



}
