using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnActiveWave;
    [SerializeField]private float timeInterval;
    [SerializeField] private int spawnRangeX;
    [SerializeField] private int spawnPosY;


    public GameObject [] prefabs;
    private List<GameObject> listObject;
   
    private float timer;

    [SerializeField] private int objectCount;
    [SerializeField] private int objectPerWave;
    [SerializeField] private int wave;
    public bool delayWave;
    [SerializeField] Vector2 speedUp;
    public float timeDelayWave;
    public float timeDelayText;

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
        delayWave = false;
        listObject = new List<GameObject>();
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (GameSetting.instance.isGameOver == false && !delayWave)
        {
            if (timer >= timeInterval)
            {
                spawnObject();
                objectCount += 1;
                timer = 0;
            }
        }

        activateWave();
     
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

    private void activateWave()
    {
        if(objectCount >= objectPerWave)
        {
            delayWave = true;
            OnActiveWave();
            timeDelayText -= Time.deltaTime;
            StartCoroutine(deactivateDelayWave());
        }
    }

    private IEnumerator deactivateDelayWave()
    {
        yield return new WaitForSeconds(timeDelayWave);
        objectCount = 0;
        timeDelayText = 5;
        delayWave = false;
        //HumanController.instance.SpeedUp(speedUp);
        //EnemyController.instance.SpeedUp(speedUp);
    }


}
