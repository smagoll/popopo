using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject prefPuddle;
    public ToxicPuddle controller;

    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        var directionPush = new Vector2(controller.character.GetDirectionToCloseEnemy().x * 0.3f, 1f);
        rb.AddForce(directionPush * controller.forcePushDrop, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            var puddle = Instantiate(prefPuddle, position: gameObject.transform.position, Quaternion.identity);
            puddle.GetComponent<Puddle>().controller = controller;
            Destroy(gameObject);
        }
    }
}
