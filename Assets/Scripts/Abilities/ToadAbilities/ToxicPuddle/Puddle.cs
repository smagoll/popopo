using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public ToxicPuddle controller;
    private double layerNumber;
    
    private float lastTimeTakeDamage = 0f;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime(controller.timePuddle));
        layerNumber = Math.Log(controller.character.layerEnemy.value, 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerNumber && Time.time - lastTimeTakeDamage > controller.freqDamage)
        {
            var enemy = collision.GetComponent<Character>();
            if (enemy != null)
            {
                enemy.TakeDamage(controller.damage);
                lastTimeTakeDamage = Time.time;
            }
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log("destroy");
    }
}
