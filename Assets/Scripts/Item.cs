using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Item : ScriptableObject
{
    public enum ItemTypes
    {
        ingredient,
        consumable,
        weapon,
        armor,
        head,
        body,
        hands,
        legs,
        feet,
        equipable,
        potion,
        food,
        other
    }

    public Image itemIcon;
    public GameObject itemObject;
    public string itemName;
    public ItemTypes[] itemTags;
    public Stats stats;

    public abstract void OnUse();

    public abstract void OnEquip();

    public abstract State OnUpdate();
}
