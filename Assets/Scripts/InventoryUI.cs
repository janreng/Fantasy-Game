using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManager.instance.OnChangedItem += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < InventoryManager.instance.items.Count)
                slots[i].AddItem(InventoryManager.instance.items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}
