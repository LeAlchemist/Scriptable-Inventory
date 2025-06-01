using Unity.VisualScripting;
using UnityEngine;

public class Weapon : Item
{
    Weapon()
    {
        itemTags = new ItemTags[]
        { ItemTags.weapon,
        ItemTags.equipable,
        ItemTags.oneHand };
    }

    public override void OnEquip()
    {
        throw new System.NotImplementedException();
    }

    public override State OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUse()
    {
        throw new System.NotImplementedException();
    }
}
