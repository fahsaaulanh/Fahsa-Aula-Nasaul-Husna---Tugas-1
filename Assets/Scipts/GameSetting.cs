using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameOver;

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

    private void OnEnable()
    {
        spawnManager.OnActiveWave += activateDelayText;
    }

    private void OnDisable()
    {
        spawnManager.OnActiveWave -= activateDelayText;
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
        OnGameOver();
        popUpGameOver.SetActive(true);
    }

    private void activateDelayText()
    {
        delayText.SetActive(true);
        StartCoroutine(deactivateDelayText());
    }

    private IEnumerator deactivateDelayText()
    {
        yield return new WaitForSeconds(spawnManager.instance.timeDelayWave);
        delayText.SetActive(false);
    }
}
