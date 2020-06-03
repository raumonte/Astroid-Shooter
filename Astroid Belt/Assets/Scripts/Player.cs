using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float turnSpeed = 90f;
    public float moveSpeed = 5f;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        void Shoot()
        {
            Debug.Log("Bang Bang");
        }
    }
}
