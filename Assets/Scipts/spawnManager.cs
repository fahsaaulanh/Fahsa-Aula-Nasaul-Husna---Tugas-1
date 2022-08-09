using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public float timeInterval;
    public int spawnRangeX;
    public int spawnPosY;

    public GameObject [] prefabs;
    private float timer;

    void Start()
    {
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            Vector2 randomSpawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY);

            int randomObject = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomObject], randomSpawnPos, prefabs[randomObject].transform.rotation);
            prefabs[randomObject].SetActive(true);
            timer = 0;
        }
    }


}
