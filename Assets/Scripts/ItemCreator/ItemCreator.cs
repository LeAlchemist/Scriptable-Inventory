using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemCreator : EditorWindow
{
    public enum Itemtype
    {
        armor,
        weapon
    }
    public enum ItemSlot
    {
        head,
        body,
        hand,
        legs,
        feet
    }
    public enum WeaponType
    {
        meleeOneHand,
        meleeTwoHand,
        rangedOneHand,
        rangedTwoHand
    }

    public Texture2D itemIcon;
    public GameObject itemObject;
    public string itemName = "New Armor";
    public Itemtype itemType;
    public ItemSlot itemSlot;
    public WeaponType weaponType;
    public Stats stats;
    public string itemDescription;
}