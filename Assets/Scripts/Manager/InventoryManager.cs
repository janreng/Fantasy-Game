using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> items = new List<Item>();
    public Action OnChangedItem;
    public Action<Item> OnEquimentItem;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        OnEquimentItem += RemoveItem;
        StatsManager.instance.OnRemoveEquipment += AddItem;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        if (OnChangedItem != null)
            OnChangedItem.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (OnChangedItem != null)
            OnChangedItem.Invoke();
    }
}
