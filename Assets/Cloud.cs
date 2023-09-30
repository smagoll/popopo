using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cloud : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("hit");
    }
}
