using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;
   
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.enabled = true;
        icon.sprite = newItem.icon;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void ShowDetail()
    {
        UIPlayManager.instance.ShowPanelDetail();
        if (DetailItemManager.instance.OnOpenDetail != null)
            DetailItemManager.instance.OnOpenDetail.Invoke(item, false);
            
    }
}
