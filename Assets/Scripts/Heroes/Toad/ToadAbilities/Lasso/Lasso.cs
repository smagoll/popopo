using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasso : MonoBehaviour
{
    public LassoController controller;
    private Vector3 direction;
    private bool isExtension = true;
    private GameObject linkedEnemy;

    private void Start()
    {
        direction = controller.character.GetDirectionToCloseEnemy();
    }

    private void Update()
    {
        if (isExtension)
        {
            Extension();
        }
        else
        {
            Attraction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hero") && collision.gameObject.layer == controller.character.layerNumber)
        {
            isExtension = false;
            if (collision.gameObject.GetComponent<Character>().isBlock == false)
            {
                linkedEnemy = collision.gameObject;
                linkedEnemy.GetComponent<Character>().isStun = true;
            }
        }
    }

    private void Extension()
    {
        if ((gameObject.transform.position - controller.character.transform.position).magnitude > controller.longitudeLasso)
        {
            isExtension = false;
            return;
        }
        gameObject.transform.position += new Vector3(direction.x, 0, 0) * controller.speedLasso;
    }

    private void Attraction()
    {
        if ((gameObject.transform.position - controller.character.transform.position).magnitude < 1f)
        {
            EndAbility();
        }

        if (linkedEnemy == null)
        {
            gameObject.transform.position -= new Vector3(direction.x, 0, 0) * controller.speedLasso;
        }
        else
        {
            gameObject.transform.position -= new Vector3(direction.x, 0, 0) * controller.speedLasso;
            linkedEnemy.transform.position = gameObject.transform.position;
        }
    }

    private void EndAbility()
    {
        controller.Cooldown();
        controller.character.ExitStun();
        controller.character.useAbility = false;

        if (linkedEnemy != null)
        {
            linkedEnemy.GetComponent<Character>().TakeStun(controller.timeStunEnemyAfterAttraction);
        }

        Destroy(gameObject);
    }
}
