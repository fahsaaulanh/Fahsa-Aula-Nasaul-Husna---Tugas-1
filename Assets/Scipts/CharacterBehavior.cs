using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehavior : MonoBehaviour
{
    [SerializeField]protected Vector3 speed;
    [SerializeField]protected Collider2D lineDead;
    protected Rigidbody2D rb;


    public abstract void moveObject();
    public abstract void SpeedUp(Vector2 magnitude);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }
}
