using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public SkorController skorControll;
    public HPController hpControll;
    public spawnManager manager;
    public Collider2D lineDead;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        hpControll.hp -= 1;

        manager.removeObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == lineDead)
        {
            skorControll._skor += 50;
            manager.removeObject(gameObject);
        }
    }
}
