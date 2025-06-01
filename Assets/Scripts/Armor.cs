using Unity.VisualScripting;
using UnityEngine;

public class Armor : Item
{
    Armor()
    {
        itemTags = new ItemTags[]
        { ItemTags.armor,
        ItemTags.equipable,
        ItemTags.body };
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
