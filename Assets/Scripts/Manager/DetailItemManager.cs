using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailItemManager : MonoBehaviour
{
    public static DetailItemManager instance;

    public Button btnEquipment, btnRemove, btnDrop;
    public Text itemName, itemAtk, itemDef, itemHp, itemPrice, itemClass, itemLevel;
    public Image itemIcon;

    public Action<Item, bool> OnOpenDetail;

    Item itemValue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        OnOpenDetail += SetInfoDetail;

        btnEquipment.onClick.AddListener(() => {
            bool condition = (itemValue.classType == CharacterType.None || itemValue.classType == GamePlayManager.instance.GetClassCharacter()) && (itemValue.level <= GamePlayManager.instance.GetLevelCharacter());
            if (condition)
            {
                UIPlayManager.instance.HidePanelDetail();
                NotificationManager.instance.ShowNotification(GamePlayManager.EQUIPMENT + itemValue.name);
                if (InventoryManager.instance.OnEquimentItem != null)
                    InventoryManager.instance.OnEquimentItem.Invoke(itemValue);
            }
            else
                NotificationManager.instance.ShowNotification(GamePlayManager.CANT_NOT_EQUIPMENT);
        });

        btnRemove.onClick.AddListener(() => {
            UIPlayManager.instance.HidePanelDetail();
            if (StatsManager.instance.OnRemoveEquipment != null)
                StatsManager.instance.OnRemoveEquipment.Invoke(itemValue);
        });

        btnDrop.onClick.AddListener(() => {
            UIPlayManager.instance.HidePanelDetail();
        });
    }

    public void SetInfoDetail(Item item, bool isEquipment)
    {
        itemValue = item;
        itemName.text = item.name;
        itemAtk.text = "ATK: " + item.damage;
        itemDef.text = "DEF: " + item.defense;
        itemHp.text = "HP: " + item.health;
        itemPrice.text = "Price: " + item.price;
        itemClass.text = "Class: " + item.classType;
        itemLevel.text = "Level: " + item.level;
        if (item.classType == GamePlayManager.instance.GetClassCharacter() || item.classType == CharacterType.None)
            itemClass.color = Color.white;
        else
            itemClass.color = Color.red;
        itemIcon.sprite = item.icon;
        ShowButtonDetail(isEquipment);
    }

    public void ShowButtonDetail(bool isEquipment = false)
    {
        if (isEquipment)
            btnEquipment.gameObject.SetActive(false);
        else
            btnRemove.gameObject.SetActive(false);
    }

    public void ResetButton()
    {
        btnEquipment.gameObject.SetActive(true);
        btnRemove.gameObject.SetActive(true);
        btnDrop.gameObject.SetActive(true);
    }
}


