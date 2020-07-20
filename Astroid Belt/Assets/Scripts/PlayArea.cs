using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    /*Using the on trigger exit gives it the chance that if any type of gameobject 
     * exits the attached play area with a collider as a trigger will delete any of those objects.
     */
    private void OnTriggerExit2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
    }
}
