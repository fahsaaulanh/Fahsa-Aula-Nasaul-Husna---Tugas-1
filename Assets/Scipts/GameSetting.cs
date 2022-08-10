using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    
   
    public GameObject popUpGameOver;
    public GameObject delayText;

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
        if(spawnManager.instance.delayWave)
        {
            StartCoroutine(activateDelayText());
            StartCoroutine(deactivateDelayText());
        }

       if(isGameOver)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
       
        popUpGameOver.SetActive(true);
    }

    private IEnumerator activateDelayText()
    {
        yield return new WaitForSeconds(0.7f);
        delayText.SetActive(true);
    }

    private IEnumerator deactivateDelayText()
    {
        yield return new WaitForSeconds(spawnManager.instance.timeDelayWave);
        delayText.SetActive(false);
    }
}
