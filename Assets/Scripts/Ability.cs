using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float manapool;
    public Character character;

    private void Start()
    {
        character = gameObject.GetComponent<Character>();
    }

    public void Launch()
    {
        Action();
    }

    public abstract void Action();
}
