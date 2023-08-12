using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Character character;

    void Start()
    {
        character = gameObject.GetComponent<Character>();
    }

    void Update()
    { 
        //character.Attack(Input.GetKey(KeyCode.H));

        if (Input.GetKey(KeyCode.J))
        {
            character.FirstAbility();
        }
    }
}
