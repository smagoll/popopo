using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = 0f;
    }
    public void UpdateMana(float mana)
    {
        slider.value = mana;
    }
}
