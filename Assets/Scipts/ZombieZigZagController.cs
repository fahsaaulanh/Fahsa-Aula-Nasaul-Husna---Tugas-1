using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieZigZagController : CharacterBehavior, IRaycastable
{
    
    [SerializeField] private float frequency;
    [SerializeField] private float t;
    [SerializeField] private float amplitudo;
    public static ZombieZigZagController instance;
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

    }


    void Update()
    {
        if (!GameSetting.instance.isGameOver && !spawnManager.instance.delayWave)
        {
            moveObject();
        }
    }

    public override void moveObject()
    {
        speed.x = 5 * Mathf.Cos(t);
        transform.position += speed * Time.deltaTime;


        t += Time.deltaTime;
    }

    public override void SpeedUp(Vector2 magnitude)
    {
        speed.y += magnitude.y;
    }


    private void OnMouseDown()
    {
        OnTapObject();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == lineDead)
        {
            HPController.instance.hp -= 1;
            spawnManager.instance.removeObject(gameObject);
        }
    }

    public void OnTapObject()
    {
        SkorController.instance._skor += 50;
        spawnManager.instance.removeObject(gameObject);
    }
}
