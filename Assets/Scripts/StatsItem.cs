using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsItem : MonoBehaviour
{
    public Image icon;

    public Item item;

    Button btnStatItem;

    private void Start()
    {
        StatsManager.instance.OnRemoveEquipment += ClearItem;
        btnStatItem = GetComponent<Button>();
        btnStatItem.onClick.AddListener(() => ShowDetail());
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.enabled = true;
        icon.sprite = newItem.icon;

        if (StatsManager.instance.OnEquipped != null)
            StatsManager.instance.OnEquipped.Invoke(item);
    }

    public void ClearItem(Item i)
    {
        if (item == i)
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void ShowDetail()
    {
        UIPlayManager.instance.ShowPanelDetail();
        DetailItemManager.instance.SetInfoDetail(item, true);
    }
}
