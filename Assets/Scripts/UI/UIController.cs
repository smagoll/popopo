using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject tableHero;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject selectionHero;
    [SerializeField]
    private GameObject options;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private GameObject cellHero;    
    [SerializeField]
    private ArrayHeroes heroes;
    private List<GameObject> cellsHero = new List<GameObject>();

    private Stack<GameObject> prevWindows = new();
    private GameObject currentWindow;

    private GameObject lastSelect;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lastSelect = EventSystem.current.firstSelectedGameObject;
    }

    private void Start()
    {
        currentWindow = menu;
        FillHeroes();
    }

    private void Update()
    {
        IgnoreMouseClick();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void ButtonPlay()
    {
        prevWindows.Push(currentWindow);
        ChangeWindow(selectionHero);
    }
    
    public void ButtonOptions()
    {
        prevWindows.Push(currentWindow);
        ChangeWindow(options);
    }
    
    public void ButtonExit()
    {
        prevWindows.Push(currentWindow);
        ChangeWindow(exit);
    }
    
    public void ButtonExitYes()
    {
        Application.Quit();
    }
    
    public void ButtonExitNo()
    {
        Back();
    }

    private void Back()
    {
        
        if (prevWindows.Count == 0)
        {
            ButtonExit();
            return;
        }
        var prevWindow = prevWindows.Pop();
        ChangeWindow(prevWindow);
    }

    private void FillHeroes()
    {
        foreach (var hero in heroes.heroes)
        {
            var cell = Instantiate(cellHero, tableHero.transform);
            cell.name = hero.Name;
            cell.GetComponent<CellHero>().heroInfo = hero;
            cell.GetComponent<CellHero>().selectionHero = selectionHero;

            var image = cell.GetComponent<Image>();
            image.sprite = hero.icon;
            cellsHero.Add(cell);
        }
        selectionHero.GetComponent<Window>().lastButton = cellsHero[0];
    }

    private void ChangeWindow(GameObject window)
    {
        currentWindow.SetActive(false);
        currentWindow = window;
        window.SetActive(true);
        window.GetComponent<Window>().lastButton.GetComponent<Button>().Select();
    }

    private void IgnoreMouseClick()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
    }
}
