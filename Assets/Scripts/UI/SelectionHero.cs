using Assets.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionHero : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private Image imageHeroLeft;
    [SerializeField]
    private TextMeshProUGUI nameHeroLeft;
    [SerializeField]
    private Image imageHeroRight;
    [SerializeField]
    private TextMeshProUGUI nameHeroRight;

    public Hero heroSelectedLeft; // выбранный герой с левой стороны
    public Hero heroSelectedRight; // выбранный герой с правой стороны
    public SelectState currentState;
    public LeftSelectState leftSelectState;
    public RightSelectState rightSelectState;

    public GameObject currentSelectedCell; // текущий выделенна€ €чейка

    private void Start()
    {
        currentSelectedCell = eventSystem.firstSelectedGameObject;

        leftSelectState = new(this, imageHeroLeft, nameHeroLeft);
        rightSelectState = new(this, imageHeroRight, nameHeroRight);

        currentState = leftSelectState;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (currentSelectedCell == eventSystem.currentSelectedGameObject || eventSystem.currentSelectedGameObject == null)
            {
                return;
            }

            currentSelectedCell = eventSystem.currentSelectedGameObject;
            var hero = currentSelectedCell.GetComponent<CellHero>();
            currentState.SetImage(hero.heroInfo);
            currentState.SetName(hero.heroInfo);
        }
    }

    public void SelectHero()
    {
        currentState.SelectHero();
    }

    public void SwitchState(SelectState selectState)
    {
        currentState = selectState;
    }

    private void OnDisable()
    {
        if (gameObject.activeSelf == false)
        {
            heroSelectedLeft = null;
            heroSelectedRight = null;
            currentState = leftSelectState;
            currentSelectedCell = null;
            imageHeroLeft.color = Color.clear;
            imageHeroRight.color = Color.clear;
        }
    }

    public void StartGame()
    {
        GameManager.heroPlayer1 = heroSelectedLeft;
        GameManager.heroPlayer2 = heroSelectedRight;
        SceneManager.LoadScene("Battle", LoadSceneMode.Single);
    }
}