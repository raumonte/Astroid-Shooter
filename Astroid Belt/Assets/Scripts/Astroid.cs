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
        //GameManager.instance.enemyList.Add(this.gameObject);
        GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();
        targetPosition = GameManager.instance.player.transform.position;
        EventBroker.PlayerDied += DestroySelf;

    }
    private void Update()
    {
        transform.position += directionToMove * moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }
    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
        EventBroker.PlayerDied -= DestroySelf;
    }
    private void DestroySelf()
        {

    }
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        
        if (otherObject.gameObject == GameManager.instance.player)
            {
            Debug.Log("Wow Buddy..");
            //This if statement activates when the player object collides into it that will bring up the debug lug.
        }
        if (otherObject.gameObject.GetComponent<Bullet>())
        {
            GameManager.instance.enemyList.Remove(this.gameObject);

            Destroy(this.gameObject);

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
