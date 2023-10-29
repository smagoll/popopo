using System;
using System.Collections;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Character character;
    public CrowCloud crowCloud;

    private void Start()
    {
        character = crowCloud.character;
    }

    private void Update()
    {
        transform.position += character.GetDirectionToCloseEnemy() * Time.deltaTime * crowCloud.speed;
        StartCoroutine(EndAbility());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var layerNumber = Math.Log(character.layerEnemy.value, 2);
        if (collision.gameObject.layer == layerNumber)
        {
            var enemy = collision.gameObject.GetComponent<Character>();
            StartCoroutine(Damage(enemy));
        }
    }

    private IEnumerator EndAbility()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private IEnumerator Damage(Character character)
    {
        float countHit = 10;
        float damageForHit = crowCloud.damage / countHit;
        for (float i = 0; i < countHit; i++)
        {
            character.TakeDamageWithStun(damageForHit);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
