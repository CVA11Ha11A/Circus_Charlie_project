using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject startUi;

    public TMP_Text playerScore;
    public TMP_Text playerHighScore;
    public TMP_Text isStage;
    public TMP_Text bonus;

    private int score = 0;

    public int stage01Scene = 0;
    // Start is called before the first frame update
    void Start()
    {
        //instance.GetComponent<GameManager>();
        instance = this;
        startUi.GetComponent<GameObject>();

        playerScore.GetComponent<TMP_Text>();
        playerHighScore.GetComponent<TMP_Text>();
        isStage.GetComponent<TMP_Text>();
        bonus.GetComponent<TMP_Text>();

        FirstIn();
    }

    private void Awake()
    {
        //�Ʒ� if �� �ڵ�� ����� IsValid �� üũ���ش�
        if (instance.IsValid() == false)
        {
            instance = this;
        }

        else
        {            
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void FirstIn()
    {
        if (stage01Scene == 0)
        {
            Invoke("Scene01On", 1f);
            stage01Scene = 1;

        }
    }


    public void Scene01On()
    {
        startUi.SetActive(false);
    }

    //���ӿ����� false�� ���ھ �þ�� �ϰ� ǥ��
    public void AddScore(int newScore)
    {
        //�Ʒ� if���� ���ӿ��� �ƴҶ� ���� �־����

        if (true)
        {
            score += newScore;
            playerScore.text = string.Format("1P-", score);
        }
    }
}
