using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellHero : MonoBehaviour
{
    public GameObject selectionHero;

    public Hero heroInfo;

    private string _name;
    private Sprite _icon;
    private Sprite _sprite;

    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public Sprite Sprite { get => _sprite; }

    private void Start()
    {
        _name = heroInfo.Name;
        _icon = heroInfo.icon;
        _sprite = heroInfo.icon;

        GetComponent<Button>().onClick.AddListener(selectionHero.GetComponent<SelectionHero>().SelectHero);
    }
}
