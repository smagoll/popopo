using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource background;

    private void Start()
    {
        background.Play();
    }
}
