using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Item : ScriptableObject
{
    public Image itemIcon;
    public GameObject itemObject;
    public string itemName;
    public ItemTags[] itemTags;
    public Stats stats;

    public abstract void OnUse();

    public abstract void OnEquip();

    public abstract State OnUpdate();
}

[System.Serializable]
public enum ItemTags
{
    ingredient,
    consumable,
    weapon,
    melee,
    ranged,
    armor,
    head,
    body,
    oneHand,
    twoHand,
    legs,
    feet,
    equipable,
    potion,
    food,
    other
}