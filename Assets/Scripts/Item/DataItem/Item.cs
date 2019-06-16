using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string name;
    public Sprite icon;
    public GameObject[] prefab;
    public ItemType type;
    public double damage;
    public double defense;
    public double health;
    public CharacterType classType;
    public double price;
    public int level;
}
