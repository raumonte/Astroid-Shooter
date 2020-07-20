using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private Vector3 directionToMove;
    private Vector3 targetPosition;
    public float moveSpeed;
    private void Start()
    {
        //Once the game starts and spawns in the astroid and adds it on the list.
        GameManager.instance.enemyList.Add(this.gameObject);
        //This has code is being used to get the last position of the player to go straight twords it. 
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        //
        directionToMove.Normalize();
        //Gives the variable targetPosition a value of the last location of the player.
        targetPosition = GameManager.instance.player.transform.position;
        // Calls the PlayerDied function from the event script to detroy any astroid in the area.
        EventBroker.PlayerDied += DestroySelf;

    }
    private void Update()
    {
        //
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }
    //In this funciton once the astroid gets destroyed it removes that astroid and checks the event handler.
    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
        EventBroker.PlayerDied -= DestroySelf;
    }
    private void DestroySelf()
        {

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
    //Once the game object leaves the collision box it activates the code with it.
    private void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("Finally you got away from me.");
    }
    //If a game object stays inside of the collision box it will activate the code within it.
    private void OnCollisionStay2D(Collision2D otherObject)
    {
        Debug.Log("Let us say can you please get away?");
    }
}
