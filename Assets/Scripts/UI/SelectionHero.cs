using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionHero : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private Image imageHero;
    [SerializeField]
    private TextMeshProUGUI nameHero;

    private GameObject currentSelectedHero;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (currentSelectedHero == eventSystem.currentSelectedGameObject)
            {
                return;
            }

            currentSelectedHero = eventSystem.currentSelectedGameObject;
            SetImage(currentSelectedHero);
            SetName(currentSelectedHero);
        }
    }

    private void SetImage(GameObject heroCell)
    {
        var hero = heroCell.GetComponent<CellHero>();
        imageHero.sprite = hero.Sprite;
        imageHero.preserveAspect = true;
    }

    private void SetName(GameObject heroCell)
    {
        var hero = heroCell.GetComponent<CellHero>();
        nameHero.text = hero.Name;
    }

    public void SelectHero()
    {
        Debug.Log(currentSelectedHero.name);
    }
}
