using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerObj;

    private Rigidbody2D playerRigid;
    private Collider2D playerCollider;

    public Collider2D underBox;

    public Animator chalriAni;

    public float playerSpeed = 5.0f;


    private int playerLife = 3;
    private bool charlieMoveBool = false;
    private bool charlieJumpBool = false;
    private bool charlieIsJump = false;

    //������ �÷��̾ �Է��ص� �������̰� �ϱ����� bool
    private bool playerInputLock = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = playerObj.GetComponent<Rigidbody2D>();
        playerCollider = playerObj.GetComponent<Collider2D>();

        chalriAni.GetComponent<Animator>();

        underBox.GetComponent<Collider2D>();
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("���̶� �ε���");

            playerInputLock = true;
            chalriAni.SetTrigger("Charlie_Die");


            Invoke("PlayerFall", 1f);

            playerLife -= 1;

            //�̴����� �ٽ� �����ϴ� ���𰡸� ������ �ҵ�

        }

    }

    private void PlayerFall()
    {
        playerCollider.isTrigger = true;
    }



    //player.AddForce(Vector2.right * h * playerSpeed * Time.deltaTime );

    //�Ʒ��� ���ǹ����� Move false �� �������� �ν��� �� �ȵǴµ�
    //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
    //{
    //    charlriMoveBool = false;
    //}



}
