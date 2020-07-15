using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ship : MonoBehaviour
{
   // private Vector3 targetPosition;
    public float rotateSpeed;
    public float moveSpeed;
    private Transform tf; // var to hold my transform

    private Vector3 myStartPosition; // var to hold start position vector of asteroid
    private Vector3 playerStartPosition; // var to hold position of player (destination)
    private Vector3 directionVector; // var to hold vector, calculate direction to travel
    private Vector3 moveVector; // var to hold and calculate direction and speed for movement

    private Vector3 myStartRotation; // var to hold start rotation vector of asteroid
    private Vector3 playerStartRotation; // var to hold rotation of player (destination)
    private float angle; // var to hold float, calculate angle to travel
    Quaternion targetRotation; // var to hold and calculate rotation

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
        tf = GetComponent<Transform>();
    }
    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //targetPosition = GameManager.instance.player.transform.position;
        //Vector3 directionToLook = targetPosition - transform.position;
        //transform.right = directionToLook;
        //directionToLook
       // transform.rotation =Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), speedOfRotation * Time.deltaTime);
        //Vector3.RotateTowards(transform.position, targetPosition, speedOfRotation);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right, transform.forward), rotationSpeed * Time.deltaTime);
    if (GameManager.instance.player != null)
        {
            //MOVEMENT
            //---------------------------------
            //Update variables every frame
            myStartPosition = tf.position; // store my position on every frame
            playerStartPosition = GameManager.instance.player.gameObject.transform.position; //store position of player on every frame

            directionVector = playerStartPosition - myStartPosition; //store diff between player and asteroid as direction on every frame
            directionVector.Normalize(); // normalize the vector to a magnitude of 1

            moveVector = directionVector * moveSpeed; //calculate the new vector

            //Move towards the point where the player was on start
            tf.position += moveVector; //move in that direction each frame at given speed on every frame


            //ROTATION
            //--------------------------------
            //Update variables every frame

            angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg; //calculate angle based on direction to player
            targetRotation = Quaternion.Euler(0, 0, angle); //update angle to rotate towards
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime); //gradually rotate towards angle times speed
        }




    }
}
