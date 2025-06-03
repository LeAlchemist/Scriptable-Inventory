using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class ArmorCreator : ItemCreator
{
    VisualElement root;

    [MenuItem("Window/Item Creator/Armor Creator")]
    public static void ShowEditor()
    {
        EditorWindow wnd = GetWindow<ArmorCreator>();
        wnd.titleContent = new GUIContent("Armor Creator");

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
            EnumField itemTypeField = new(ItemCreator.Itemtype.armor)
            {
                label = "Item Type:",
            };
            itemTypeField.SetEnabled(false);
            root.Add(itemTypeField);

            itemType = ItemCreator.Itemtype.armor;
        }
        #endregion
        #region Item Slot Field
        {
            EnumField itemSlotField = new(ItemCreator.ItemSlot.head)
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
                        itemSlot = ItemCreator.ItemSlot.head;
                        break;
                    case "Body":
                        itemSlot = ItemCreator.ItemSlot.body;
                        break;
                    case "Hand":
                        itemSlot = ItemCreator.ItemSlot.hand;
                        break;
                    case "Legs":
                        itemSlot = ItemCreator.ItemSlot.legs;
                        break;
                    case "Feet":
                        itemSlot = ItemCreator.ItemSlot.feet;
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

    }

    public void CreateArmorHead(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.head };
    }

    public void CreateArmorBody(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.body };
    }

    public void CreateArmorHand(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.oneHand };
    }

    public void CreateArmorLegs(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.legs };
    }

    public void CreateArmorFeet(Texture2D _itemicon, GameObject _itemobject, string _itemName, Stats _stats)
    {
        var armor = ScriptableObject.CreateInstance<Armor>();
        armor.itemIcon = _itemicon;
        armor.itemObject = _itemobject;
        armor.itemName = _itemName;
        armor.stats = _stats;
        armor.itemTags = new ItemTags[3] { ItemTags.armor, ItemTags.equipable, ItemTags.feet };
    }
}
