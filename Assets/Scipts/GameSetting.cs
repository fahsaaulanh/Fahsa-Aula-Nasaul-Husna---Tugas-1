using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    
    public HPController hpControll;
    public GameObject popUpGameOver;
    void Start()
    {
        
    }

    void Update()
    {
        if(hpControll.hp == 0)
        {
            popUpGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
