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
        

    //�ִϸ��̼� Any State �� ����Ҷ��� bool �������� ����
    //���ǹ��� �������� Triger�� ����
    //private bool isgole = false;

    //������ �÷��̾ �Է��ص� �������̰� �ϱ����� bool
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

        // �÷��̾� �̵�

        //������ Ű �Է��ϸ� �� �Լ�
        if (Input.anyKey)
        {
            UserInput();
        }

        //������ Ű �Է��� ���� �ʾ����� �� �Լ�
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

            //�����̽��� ������ ����
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

            //���� �ϸ� �����ϼ� �ִ� �� ������Ʈ ����
            Destroy(fireringSponer);
            
            Destroy(firering);
           




            chalriAni.SetTrigger("Charlie_ClearTr");

            playerInputLock = true;





            for (int i = 0; i < 20; i++)
            {
                //Debug.LogFormat("���° ���� �ִ��� : {0}", i);
                Invoke("ClearBackground", 0.5f * i);

            }



        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Debug.Log("���̶� �ε���");

            playerInputLock = true;
            chalriAni.SetTrigger("Charlie_Die");

            charlieAudioSource.clip = dieSound;
            charlieAudioSource.Play();
            GameManager.instance.stage01_ThemeOff = 1;


            Invoke("PlayerFall", 1f);

            playerLife -= 1;

            //�̴����� �ٽ� �����ϴ� ���𰡸� ������ �ҵ�

        }

    }

    private void PlayerFall()
    {
        playerCollider.isTrigger = true;
    }

    private void ClearBackground()
    {
        //Debug.LogFormat("���° ���� �ִ���");
        if (backgroundPeoples == true)
        {
            //Debug.LogFormat("������");
            backgroundPeoples = false;
            backgroundPeople01.SetActive(false);
            backgroundPeople02.SetActive(false);

        }

        else if (backgroundPeoples == false)
        {
            //Debug.LogFormat("������");
            //Enable
            backgroundPeoples = true;
            backgroundPeople01.SetActive(true);
            backgroundPeople02.SetActive(true);            
            //async

        }


    }


    //player.AddForce(Vector2.right * h * playerSpeed * Time.deltaTime );

    //�Ʒ��� ���ǹ����� Move false �� �������� �ν��� �� �ȵǴµ�
    //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
    //{
    //    charlriMoveBool = false;
    //}



}
