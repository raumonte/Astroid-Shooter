using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    public GameObject playerPrefab;
    public List<GameObject> enemyList;
    public List<GameObject> enemyPrefabList;
    public List<Transform> spawnPointList;
    public float spawnDistance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("[GameManager] Attempted to create a second game manager.");
        }
    }
    public void SpawnEnemy()
    {
        //Pick a random enemy to spawn
        GameObject enemyToSpawn = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)];

        //Pick a random spawn point to spawn at.

        Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];
        //These two lines help to pick a point on where the spawn point is to spawn the enemies at.
        Vector3 randomVector = Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);
        Instantiate(enemyToSpawn, newPosition, Quaternion.identity);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (player != null)
        {
         if (enemyList.Count < 3)
         {
                SpawnEnemy();
         }
        }

    }
    private void SpawnPlayer()
    {
        if (player != null)
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }
    public void DefeatAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
