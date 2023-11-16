using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public BubbleController controller;
    private float lastTimeTakeDamage = 0f;

    void Start()
    {
        StartCoroutine(DestroyAfterTime(controller.timeBubble));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("hero") && collision.gameObject.layer == controller.character.layerNumber)
        {
            if (Time.time - lastTimeTakeDamage > controller.freqDamage)
            {
                var enemy = collision.GetComponent<Character>();
                if (enemy != null)
                {
                    enemy.TakeDamage(controller.damage);
                    lastTimeTakeDamage = Time.time;
                }
            }
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        controller.isActive = false;
        Destroy(gameObject);
    }
}
