using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] StatsItem[] statsItemsWeapon;
    [SerializeField] StatsItem[] statsItemsArmor;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManager.instance.OnEquimentItem += UpdateUI;
    }

    void UpdateUI(Item item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                statsItemsWeapon[0].AddItem(item);
                break;
            case ItemType.Bracer:
                statsItemsWeapon[1].AddItem(item);
                break;
            case ItemType.Shoulder:
                statsItemsWeapon[2].AddItem(item);
                break;
            case ItemType.Armor:
                statsItemsArmor[0].AddItem(item);
                break;
            case ItemType.Helmet:
                statsItemsArmor[1].AddItem(item);
                break;
            case ItemType.Sheild:
                statsItemsArmor[2].AddItem(item);
                break;
        }
    }

}
