using UnityEngine;

[System.Serializable]
public class Stats
{
    public enum StatTypes
    {
        currentHp,
        totalHp,
        currentMana,
        totalMana,
        agility,
        presence,
        strength,
        toughness
    }

    public int currentHp, totalHp, currentMana, totalMana;
    public int agility, presence, strength, toughness;

}
