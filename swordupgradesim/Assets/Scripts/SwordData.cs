using UnityEngine;
[CreateAssetMenu(fileName = "SwordData", menuName = "Game/Sword")]

public class SwordData : ScriptableObject
{
    public string swordName;
    public int cost;
    public int baseDmg;
    public Sprite icon;
}