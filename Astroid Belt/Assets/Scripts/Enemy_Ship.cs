using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ship : MonoBehaviour
{
    public float rotateSpeed;
    public float moveSpeed;
    private Transform tf;

    private Vector3 myStartPosition;
    private Vector3 playerStartPosition; 
    private Vector3 directionVector;
    private Vector3 moveVector;

    private Vector3 myStartRotation; 
    private Vector3 playerStartRotation;
    private float angle; 
    Quaternion targetRotation; 

  
    void Start()
    {
        //This makes the enemy ship an enemy object to add on the list of items.
        GameManager.instance.enemyList.Add(this.gameObject);
        tf = GetComponent<Transform>();
    }
    private void OnDestroy()
    {
        //once destroyed it will remove the ship from the scene and list.
        GameManager.instance.enemyList.Remove(this.gameObject);
    }
    //Whenever an object collides with the astroid it will begin to activate any code within the function.
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        // This if statment gets activated once the player collides with the astroid.
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("Wow Buddy..");
        }
        // This if statment activates once a game object containing the Bullet script collides with the astroid.
        if (otherObject.gameObject.GetComponent<Bullet>())
        {
            GameManager.instance.enemyList.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
    }
    void Update()
    {
        //Using this if stament activates when the player is still present in the scene.
    if (GameManager.instance.player != null)
        {
            //The rotation of the object will equal the same as the target's position.
            myStartPosition = tf.position; 

            //This will get the position of the player from the game manager.
            playerStartPosition = GameManager.instance.player.gameObject.transform.position;

            //Having the difference of the position of the player and enemyship to be able to see where the player may be.
            directionVector = playerStartPosition - myStartPosition;
            directionVector.Normalize();

            moveVector = directionVector * moveSpeed; //calculate the new vector

            //Move towards the point where the player was on start
            tf.position += moveVector;
            
            //uses math to calculate the angle of where the enemy ship has to look at.
            angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg; 

            //This helps in getting the update of the angle so it can look at the player.
            targetRotation = Quaternion.Euler(0, 0, angle);
            
            //Helps to actually turn the object to look at the target that has been targeted.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }




    }
}
