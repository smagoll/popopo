using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LeftSelectState : SelectState
    {
        public LeftSelectState(SelectionHero selectionHero, Image image, TextMeshProUGUI nameHeroObject) : base(selectionHero, image, nameHeroObject) { }

        public override void SelectHero()
        {
            var hero = selectionHero.currentSelectedCell.GetComponent<CellHero>().heroInfo;
            selectionHero.heroSelectedLeft = hero;
            selectionHero.currentSelectedCell = null;
            selectionHero.SwitchState(selectionHero.rightSelectState);
        }
    }
}