using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SelectState
{
    public TextMeshProUGUI nameHero;
    public Image imageHero;
    public SelectionHero selectionHero;

    public SelectState(SelectionHero selectionHero, Image imageObject, TextMeshProUGUI nameHeroObject)
    {
        this.selectionHero = selectionHero;
        nameHero = nameHeroObject;
        imageHero = imageObject;
    }

    public void ChangeHeroSelection()
    {

    }

    public abstract void SelectHero();

    public void SetImage(Hero hero)
    {
        imageHero.color = Color.white;
        imageHero.sprite = hero.icon;
        imageHero.preserveAspect = true;
    }

    public  void SetName(Hero hero)
    {
        nameHero.text = hero.Name;
    }
}
