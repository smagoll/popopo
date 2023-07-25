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
        float axisValue = Input.GetAxis("Horizontal");
        character.Move(axisValue);

        if (Input.GetKey(KeyCode.W))
        {
            character.Jump();
        }

        character.Attack(Input.GetKey(KeyCode.H));

    }
}
