using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;

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
}
