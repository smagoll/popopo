using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static InputAsset input;
    public static Hero heroPlayer1;
    public static Hero heroPlayer2;
    [SerializeField]
    private Transform spawnPlayer1;
    [SerializeField]
    private Transform spawnPlayer2;
    public HealthBar hpBar1;
    public HealthBar hpBar2;
    public ManaBar mpBar1;
    public ManaBar mpBar2;

    public bool isPause = false;
    [SerializeField]
    private GameObject PauseUI;

    private void Awake()
    {
        GlobalEventManager.EndGame.AddListener(EndGame);
        input = Resources.Load<InputAsset>("Data/Inputs/PlayerOne");
        if (heroPlayer1 != null && heroPlayer2 != null)
        {
            Spawn();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void Spawn()
    {
        var player1 = Instantiate(heroPlayer1.prefab, position: spawnPlayer1.position, Quaternion.identity);
        player1.AddComponent<CharacterStateMachine>();
        var charPlayer1 = player1.GetComponent<Character>();
        charPlayer1.healthBar = hpBar1;
        charPlayer1.manaBar = mpBar1;
        charPlayer1.layerEnemy = LayerMask.GetMask("Team2");
        player1.gameObject.layer = LayerMask.NameToLayer("Team1"); 

        var player2 = Instantiate(heroPlayer2.prefab, position: spawnPlayer2.position, Quaternion.identity);
        player2.AddComponent<AIStateMachine>();
        var charPlayer2 = player2.GetComponent<Character>();
        charPlayer2.healthBar = hpBar2;
        charPlayer2.manaBar = mpBar2;
        charPlayer2.layerEnemy = LayerMask.GetMask("Team1");
        player2.gameObject.layer = LayerMask.NameToLayer("Team2");
    }

    private void EndGame()
    {
        StartCoroutine(TimerBeforeQuit());
    }

    private IEnumerator TimerBeforeQuit()
    {
        yield return new WaitForSeconds(5f);
        ExitToMenu();

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
        isPause = true;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseUI.SetActive(false);
        isPause = false;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
