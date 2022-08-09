using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkorController : MonoBehaviour
{
    public int _skor;

    public static SkorController instance;

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
    void Start()
    {
        _skor = 0;
    }

  
    void Update()
    {
        
    }
}
