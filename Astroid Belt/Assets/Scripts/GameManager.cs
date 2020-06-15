using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    public List<GameObject> enemyList;
    public List<GameObject> enemySpawnList;
    public List<Transform> spawnPointList;

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
        //Pick a random spawn point to spawn at.

        Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];
    }
}
