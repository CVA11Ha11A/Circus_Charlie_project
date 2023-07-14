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
        //아래 if 문 코드와 비슷함 IsValid 가 체크해준다
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

    //게임오버가 false면 스코어가 늘어나게 하고 표시
    public void AddScore(int newScore)
    {
        //아래 if문에 게임오버 아닐때 조건 넣어야함

        if (true)
        {
            score += newScore;
            playerScore.text = string.Format("1P-", score);
        }
    }
}
