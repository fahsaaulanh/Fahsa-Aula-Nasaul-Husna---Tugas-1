using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{


    [SerializeField] private GameObject popUpGameOver;
    [SerializeField] private GameObject delayText;

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
        yield return new WaitForSeconds(0.001f);
        delayText.SetActive(true);
        StartCoroutine(deactivateDelayText());
    }

    private IEnumerator deactivateDelayText()
    {
        yield return new WaitForSeconds(spawnManager.instance.timeDelayWave);
        delayText.SetActive(false);
    }
}
