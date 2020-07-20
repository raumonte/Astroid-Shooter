using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gives the bullet a place to spawn once this class activates.
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }
}
