using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SkorController skorControll;
    public HPController hpControll;
    public Collider2D lineDead;

    void Start()
    {
        
    }

   
    void Update()
    {
      
    }

    private void OnMouseDown()
    {
        skorControll._skor += 50;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == lineDead)
        {
            hpControll.hp -= 1;
            Destroy(gameObject);
        }
    }

}
