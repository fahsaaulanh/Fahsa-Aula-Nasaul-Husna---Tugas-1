using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    public int skor ;
    public int hp;
    
    public TMP_Text skorText;
    public TMP_Text hpText;
    void Start()
    {
        
    }

   
    void Update()
    {
        skor = SkorController.instance._skor;
        skorText.text = skor.ToString();

        hp = HPController.instance.hp;
        hpText.text = hp.ToString();
    }
}
