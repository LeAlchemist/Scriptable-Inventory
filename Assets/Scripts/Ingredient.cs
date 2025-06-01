using Unity.VisualScripting;
using UnityEngine;

public class Ingredient : Item
{
    Ingredient()
    {
        itemTags = new ItemTags[]
        { ItemTags.other};
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
