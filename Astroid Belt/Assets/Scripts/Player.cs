using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //turn Speed goes by degrees per second
    public float turnSpeed = 90f;
    
    //moveSpeed goes by meters per second or a unity unit per second
    public float moveSpeed = 5f;


    private Transform tf;

    //Within this function it contains the if statements of rotating the object when using the left and right arrow keys.
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

    //Within the function it contains the if statements of how the object will move. In this case having the object going up and down with the respective position.
    public void MovementOfObject()
    {
        //Once the player presses the Up Arrow Key the object will move up to it's relative rotated position. 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
            //tf.position += tf.up * moveSpeed * Time.deltaTime;
        }

        //Once the player presses the Down Arrow Key the object will reverse or go down to it's relative rotated position.
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);
        }

    }

    //This function contains the code to be able to shoot from the object.
    public void Shoot()
    {
        Debug.Log("Bang Bang");
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
        //Rotation and Movement of Object are being called which each contain their respective code.
        RotationOfObject();

        MovementOfObject();

        //When the space key is pressed it will call the function that contain's it's respective code.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
  

}
