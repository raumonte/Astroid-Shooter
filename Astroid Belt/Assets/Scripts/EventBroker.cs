using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBroker
{
    public static event Action PlayerDied;
    
    public static void CallPlayerDied()
    {
        if (PlayerDied != null)
        {
            PlayerDied();
        }
    }
}
