using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Armor")]
public class Armor : Item
{
    Armor()
    {
        itemTags = new ItemTypes[]
        { ItemTypes.armor,
        ItemTypes.equipable,
        ItemTypes.body };
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
