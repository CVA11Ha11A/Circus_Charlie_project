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

    AudioSource stage1_Theme;

    private float score = 0;

    
    public bool isStageClear = false;

    public int stage01_ThemeOff = 0;
    public int scoreCount = 1;
    public int stage01Scene = 0;




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
        stage1_Theme = GetComponent<AudioSource>();
        stage1_Theme.Stop();
        FirstIn();
    }


    // Update is called once per frame
    void Update()
    {


        if(stage01_ThemeOff == 1)
        {
            stage01_ThemeOff = 2;
            stage1_Theme.Stop();
        }

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
        stage1_Theme.Play();
    }

    //���ӿ����� false�� ���ھ �þ�� �ϰ� ǥ��
    public void AddScore()
    {
        //�Ʒ� if���� ���ӿ��� �ƴҶ� ���� �־����

        if (true)
        {
            score += 10;
            playerScore.text = string.Format("1P-", score);
        }
    }
}


