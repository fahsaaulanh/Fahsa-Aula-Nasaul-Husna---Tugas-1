using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    
   
    public GameObject popUpGameOver;

    [HideInInspector] public bool isGameOver = false;

    public static GameSetting instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
       if(isGameOver)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
       
        popUpGameOver.SetActive(true);
    }
}
