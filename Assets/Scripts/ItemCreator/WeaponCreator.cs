using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponCreator : ItemCreator
{
    VisualElement root;

    [MenuItem("Window/Item Creator/Weapon Creator")]
    public static void ShowEditor()
    {
        EditorWindow wnd = GetWindow<WeaponCreator>();
        wnd.titleContent = new GUIContent("Weapon Creator");

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
                label = "Item Name:",
                value = itemName
            };
            itemNameField.AddToClassList("itemNameField");
            root.Add(itemNameField);

            itemNameField.RegisterCallback<ChangeEvent<string>>((evt) =>
            {
                itemName = evt.newValue;
            });
        }
        #endregion
        #region Item Icon Field
        {
            ObjectField itemIconField = new()
            {
                label = "Item Icon:",
                objectType = typeof(Sprite)
            };
            itemIconField.AddToClassList("itemIconField");
            root.Add(itemIconField);
        }
        #endregion
        #region Item Object Field
        {
            ObjectField itemObjectField = new()
            {
                label = "Item Object:",
                objectType = typeof(GameObject)
            };
            itemObjectField.AddToClassList("itemIconField");
            root.Add(itemObjectField);
        }
        #endregion
        #region Item Type Field
        {
            EnumField itemTypeField = new(Itemtype.weapon)
            {
                label = "Item Type:",
            };
            itemTypeField.SetEnabled(false);
            root.Add(itemTypeField);

            itemType = Itemtype.weapon;
        }
        #endregion
        #region Item Slot Field
        {
            EnumField itemSlotField = new(ItemSlot.hand)
            {
                label = "Item Slot:"
            };
            itemSlotField.AddToClassList("itemSlotField");
            itemSlotField.SetEnabled(false);
            root.Add(itemSlotField);

            itemSlot = ItemSlot.hand;
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
        #region Stat Field
        {
            Foldout statsField = new()
            {
                text = "Stats"
            };
            root.Add(statsField);

            IntegerField statsFieldAgility = new()
            {
                label = "Agility:"
            };
            statsField.Add(statsFieldAgility);

            statsFieldAgility.RegisterCallback<ChangeEvent<int>>((evt) =>
            {
                stats.agility = (int)evt.newValue;
            });

            IntegerField statsFieldPresence = new()
            {
                label = "Presence:"
            };
            statsField.Add(statsFieldPresence);

            statsFieldPresence.RegisterCallback<ChangeEvent<int>>((evt) =>
            {
                stats.presence = (int)evt.newValue;
            });

            IntegerField statsFieldStrength = new()
            {
                label = "Strength:"
            };
            statsField.Add(statsFieldStrength);

            statsFieldStrength.RegisterCallback<ChangeEvent<int>>((evt) =>
            {
                stats.strength = (int)evt.newValue;
            });

            IntegerField statsFieldToughness = new()
            {
                label = "Toughness:"
            };
            statsField.Add(statsFieldToughness);

            statsFieldToughness.RegisterCallback<ChangeEvent<int>>((evt) =>
            {
                stats.toughness = (int)evt.newValue;
            });
        }
        #endregion
        #region Item Description
        {
            Label itemDescriptionLabel = new("Description:");
            root.Add(itemDescriptionLabel);

            TextField itemDescriptionField = new()
            {
                multiline = true,
            };
            itemDescriptionField.AddToClassList("ItemDescriptionField");
            root.Add(itemDescriptionField);

            itemDescriptionField.RegisterCallback<ChangeEvent<string>>((evt) =>
            {
                itemDescription = evt.newValue;
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

    public void CreateItem()
    {
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

    }

    public void CreateWeaponMeleeOneHand(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.melee, ItemTags.oneHand };
    }

    public void CreateWeaponMeleeTwoHand(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.melee, ItemTags.twoHand };
    }

    public void CreateWeaponRangedOneHand(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.ranged, ItemTags.oneHand };
    }

    public void CreateWeaponRangedTwoHand(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var weapon = ScriptableObject.CreateInstance<Weapon>();
        weapon.itemIcon = _itemicon;
        weapon.itemObject = _itemobject;
        weapon.itemName = _itemName;
        weapon.stats = _stats;
        weapon.itemTags = new ItemTags[4] { ItemTags.weapon, ItemTags.equipable, ItemTags.ranged, ItemTags.twoHand };
    }
}