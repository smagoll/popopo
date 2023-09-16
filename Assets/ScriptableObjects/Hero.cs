using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero Asset", menuName = "Hero")]
public class Hero : ScriptableObject
{
    public string Name;
    public Sprite icon;
}
