using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int stage01Scene = 0;

    public GameObject startUi;
    // Start is called before the first frame update
    void Start()
    {
        instance.GetComponent<GameManager>();
        startUi.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        FirstIn();

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

}
