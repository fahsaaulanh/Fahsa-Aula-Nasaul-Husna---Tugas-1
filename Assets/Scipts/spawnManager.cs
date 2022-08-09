using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public float timeInterval;
    public int spawnRangeX;
    public int spawnPosY;

    public GameObject [] prefabs;
    private List<GameObject> listObject;
   
    private float timer;

    public static spawnManager instance;

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
        listObject = new List<GameObject>();
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if(GameSetting.instance.isGameOver == false)
        {
            if (timer >= timeInterval)
            {
                spawnObject();
                timer = 0;
            }
        }
     
    }

    private void spawnObject()
    {
        Vector2 randomSpawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY);

        int randomObject = Random.Range(0, prefabs.Length);
        GameObject prefabsObject = Instantiate(prefabs[randomObject], randomSpawnPos, prefabs[randomObject].transform.rotation);
        prefabsObject.SetActive(true);
        listObject.Add(prefabsObject);
    }

    public void removeObject(GameObject prefabsObject)
    {
        Destroy(prefabsObject);
        listObject.Remove(prefabsObject);
    }


}
