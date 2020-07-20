using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //This variable is for the event of player death.
    public event Action PlayerDied;
    
    //turn Speed goes by degrees per second
    public float turnSpeed = 90f;
    
    //moveSpeed goes by meters per second or a unity unit per second
    public float moveSpeed = 6f;

    //This variable gives the transform a name to be able to be used in code for moving or rotating the object.
    private Transform tf;

    //The variable gives the designer to assign the gameobject for the bullet to spawn.
    public GameObject bulletPrefab;
    
    //The variable gives the designers the chance to edit the speed of the bullet.
    public float bulletSpeed = 6f;

    //Within the RotationOfObject function it contains the if statements of rotating the object when using the left and right arrow keys.
    public void RotationOfObject()
    {
        //When the player presses the Left Arrow key the object will rotate to the relative z-axis depedning on how many degrees are applied to turn it. 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        //When the player presses the Right Arrow key the object will rotate to the relative negative z-axis depedning on how many degrees are applied to turn it. 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
    }

    //Within the MovementOfObject function it contains the if statements of how the object will move. In this case having the object going up and down with the respective position.
    public void MovementOfObject()
    {
        //Once the player presses the Up Arrow Key the object will move up to it's relative rotated position. 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        }

        //Once the player presses the Down Arrow Key the object will reverse or go down to it's relative rotated position.
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Within the update it calls the Rotation and Movement of Object function per frame for the tank controls of the player.
        RotationOfObject();

        MovementOfObject();

        //When the space key is pressed it will call the function for the bullet.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
     void Shoot()
    {
        //The next two lines of code is used to spawn in the bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        /*Once the player collides with any type of game object with 
         collison it will call the function to kill the player. */
        DeathOfPlayer();
    }
    private void DeathOfPlayer()
    {
        //In this function it basically destroys the object that has this script attached to it.
        EventBroker.CallPlayerDied();
        Destroy(this.gameObject);
    }
    void OnDestroy()
    {
        //Once the player gets destroyed it will give it the status of null which tis to other lines of code.
        GameManager.instance.player = null;
    }
}