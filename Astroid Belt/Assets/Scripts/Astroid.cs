using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private Vector3 directionToMove;
    public float moveSpeed;
    private void Start()
    {
        //GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();

    }
    private void Update()
    {
        transform.position += directionToMove * moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, moveSpeed * Time.deltaTime);

    }
    private void OnDestroy()
    {
        //GameManager.instance.enemyList.Remove(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("STOP!!");
        if (otherObject.gameObject == GameManager.instance.player)
            {
            Debug.Log("Wow Buddy..");
            //This if statement activates when the player object collides into it that will bring up the debug lug.
        }
    }
    private void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("Finally you got away from me.");
    }
    private void OnCollisionStay2D(Collision2D otherObject)
    {
        Debug.Log("Let us say can you please get away?");
    }
}
