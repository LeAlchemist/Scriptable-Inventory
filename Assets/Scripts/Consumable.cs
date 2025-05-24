using Unity.VisualScripting;
using UnityEngine;

public class Consumable : Item
{
    Consumable()
    {
        itemTags = new ItemTypes[]
        { ItemTypes.consumable };
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
