using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class RightSelectState : SelectState
    {
        public RightSelectState(SelectionHero selectionHero, Image imageObject, TextMeshProUGUI nameHeroObject) : base(selectionHero, imageObject, nameHeroObject) { }

        public override void SelectHero()
        {
            selectionHero.heroSelectedRight = selectionHero.currentSelectedCell.GetComponent<CellHero>().heroInfo;
            selectionHero.StartGame();
        }

    }
}