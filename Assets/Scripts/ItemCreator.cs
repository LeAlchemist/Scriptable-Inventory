using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemCreator : EditorWindow
{
    public Image itemIcon;
    public GameObject itemObject;
    public string itemName = "New Item";
    public enum Itemtype
    {
        armor,
        weapon
    }
    public Itemtype itemType;
    public enum ItemSlot
    {
        head,
        body,
        hand,
        legs,
        feet
    }
    public ItemSlot itemSlot;
    public enum WeaponType
    {
        meleeOneHand,
        meleeTwoHand,
        rangedOneHand,
        rangedTwoHand
    }
    public WeaponType weaponType;
    public Stats stats;
    VisualElement root;

    [MenuItem("Window/Item Creator")]
    public static void ShowEditor()
    {
        EditorWindow wnd = GetWindow<ItemCreator>();
        wnd.titleContent = new GUIContent("Item Creator");

        // Limit size of the window.
        wnd.minSize = new Vector2(450, 200);
        wnd.maxSize = new Vector2(1920, 720);
    }

    public void CreateGUI()
    {
        root = rootVisualElement;

        #region Item Name Field
        {
            TextField itemNameField = new()
            {
                label = "Item Name:"
            };
            itemNameField.AddToClassList("itemNameField");
            root.Add(itemNameField);

            itemNameField.RegisterCallback<ChangeEvent<string>>((evt) =>
            {
                itemName = evt.newValue;
            });
        }
        #endregion
        #region Item Type Field
        {
            EnumField itemTypeField = new(Itemtype.armor)
            {
                label = "Item Type:",
            };
            itemTypeField.AddToClassList("itemTypeField");

            root.Add(itemTypeField);

            itemTypeField.RegisterCallback<ChangeEvent<string>>((evt) =>
            {
                switch (evt.newValue)
                {
                    case "Armor":
                        itemType = Itemtype.armor;
                        break;
                    case "Weapon":
                        itemType = Itemtype.weapon;
                        itemSlot = ItemSlot.hand;
                        break;
                }
            });
        }
        #endregion
        #region Item Slot Field
        {
            EnumField itemSlotField = new(ItemSlot.head)
            {
                label = "Item Slot:"
            };
            itemSlotField.AddToClassList("itemSlotField");
            root.Add(itemSlotField);

            itemSlotField.RegisterCallback<ChangeEvent<string>>((evt) =>
            {
                switch (evt.newValue)
                {
                    case "Head":
                        itemSlot = ItemSlot.head;
                        break;
                    case "Body":
                        itemSlot = ItemSlot.body;
                        break;
                    case "Hand":
                        itemSlot = ItemSlot.hand;
                        break;
                    case "Legs":
                        itemSlot = ItemSlot.legs;
                        break;
                    case "Feet":
                        itemSlot = ItemSlot.feet;
                        break;
                }
            });
        }
        #endregion
        #region Weapon Type
        {
            EnumField itemWeaponField = new(WeaponType.meleeOneHand)
            {
                label = "Weapon Type:"
            };
            itemWeaponField.AddToClassList("itemWeaponField");
            root.Add(itemWeaponField);

            itemWeaponField.RegisterCallback<ChangeEvent<string>>((evt) =>
            {
                switch (evt.newValue)
                {
                    case "Melee One Hand":
                        weaponType = WeaponType.meleeOneHand;
                        break;
                    case "Melee Two Hand":
                        weaponType = WeaponType.meleeTwoHand;
                        break;
                    case "Ranged One Hand":
                        weaponType = WeaponType.rangedOneHand;
                        break;
                    case "Ranged Two Hand":
                        weaponType = WeaponType.rangedTwoHand;
                        break;
                }
            });
        }
        #endregion
        #region Create Item Button
        {
            Button createItemButton = new(() =>
            {
                CreateItem();
            })
            {
                text = "Create Item"
            };
            createItemButton.AddToClassList("createItemButton");
            root.Add(createItemButton);
        }
        #endregion
    }

    public void OnInspectorUpdate()
    {
        //Debug.Log($"{itemName} {itemType} {itemSlot} {weaponType}");

        for (int i = 0; i < root.childCount - 1; i++)
        {
            switch (itemType)
            {
                case Itemtype.armor:
                    root[i].AddToClassList("armor");
                    root[i].RemoveFromClassList("weapon");
                    break;
                case Itemtype.weapon:
                    root[i].AddToClassList("weapon");
                    root[i].RemoveFromClassList("armor");
                    break;
            }
        }
    }

    public void CreateItem()
    {
        Debug.Log($"{itemName} {itemType} {itemSlot} {weaponType}");

        switch (itemType)
        {
            case Itemtype.armor:
                switch (itemSlot)
                {
                    case ItemSlot.head:
                        CreateArmorHead(itemIcon, itemObject, itemName, stats);
                        break;
                    case ItemSlot.body:
                        CreateArmorBody(itemIcon, itemObject, itemName, stats);
                        break;
                    case ItemSlot.hand:
                        CreateArmorHand(itemIcon, itemObject, itemName, stats);
                        break;
                    case ItemSlot.legs:
                        CreateArmorLegs(itemIcon, itemObject, itemName, stats);
                        break;
                    case ItemSlot.feet:
                        CreateArmorFeet(itemIcon, itemObject, itemName, stats);
                        break;
                }
                break;
            case Itemtype.weapon:
                switch (weaponType)
                {
                    case WeaponType.meleeOneHand:
                        CreateWeaponMeleeOneHand(itemIcon, itemObject, itemName, stats);
                        break;
                    case WeaponType.meleeTwoHand:
                        CreateWeaponMeleeTwoHand(itemIcon, itemObject, itemName, stats);
                        break;
                    case WeaponType.rangedOneHand:
                        CreateWeaponRangedOneHand(itemIcon, itemObject, itemName, stats);
                        break;
                    case WeaponType.rangedTwoHand:
                        CreateWeaponRangedTwoHand(itemIcon, itemObject, itemName, stats);
                        break;
                }
                break;
        }
    }

    public void CreateArmorHead(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.head };
    }

    public void CreateArmorBody(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.body };
    }

    public void CreateArmorHand(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.oneHand };
    }

    public void CreateArmorLegs(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.legs };
    }

    public void CreateArmorFeet(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.feet };
    }

    public void CreateWeaponMeleeOneHand(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.melee, ItemTags.oneHand };
    }

    public void CreateWeaponMeleeTwoHand(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.melee, ItemTags.twoHand };
    }

    public void CreateWeaponRangedOneHand(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.ranged, ItemTags.oneHand };
    }

    public void CreateWeaponRangedTwoHand(Image _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.ranged, ItemTags.twoHand };
    }
}