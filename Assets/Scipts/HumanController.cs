using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    
    public Collider2D lineDead;

    public Vector2 speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if( ! GameSetting.instance.isGameOver)
        {
            moveObject();
        }
    }

    private void moveObject()
    {
        rb.velocity = speed;
    }

    private void OnMouseDown()
    {
        GameSetting.instance.isGameOver = true;
        spawnManager.instance.removeObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == lineDead)
        {
            SkorController.instance._skor += 50;
            spawnManager.instance.removeObject(gameObject);
        }
    }
}
