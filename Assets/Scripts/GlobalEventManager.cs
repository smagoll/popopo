using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent EndGame = new();

    public static void Start_EndGame()
    {
        EndGame.Invoke();
    }
}
