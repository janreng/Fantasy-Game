using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;

    [SerializeField] Text name, className, level, attack, armor, health;

    public GameObject characterStats;
    public GameObject characterPlayer;
    public Action<Item> OnEquipped;
    public Action<Item> OnRemoveEquipment;

    CharacterSlot characterSlotModel;
    CharacterSlot characterSlotPlayer;
    CharacterAttribute characterAttribute;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        OnEquipped += ChangeItemModel;
        OnRemoveEquipment += RemoveItemModel;
        characterSlotModel = characterStats.GetComponentInChildren<CharacterSlot>();
        characterSlotPlayer = characterPlayer.GetComponentInChildren<CharacterSlot>();
        characterAttribute = characterPlayer.GetComponentInChildren<CharacterAttribute>();
    }

    public void SetStats(CharacterAttribute attribute)
    {
        name.text = "Name: " + attribute.name;
        className.text = "Class: " + attribute.type.ToString();
        level.text = "Level: " + attribute.level.ToString();
        attack.text = attribute.damage.ToString();
        armor.text = attribute.armor.ToString();
        health.text = attribute.health.ToString();
    }

    public void LevelUp(int levelUp)
    {
        level.text = "Level: " + levelUp.ToString();
    }

    public void ChangeItemModel(Item item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                Instantiate(item.prefab[0], characterSlotModel.weaponRight.transform);
                Instantiate(item.prefab[0], characterSlotPlayer.weaponRight.transform);
                break;
            case ItemType.Bracer:
                //right
                Instantiate(item.prefab[0], characterSlotModel.braceRight.transform);
                Instantiate(item.prefab[0], characterSlotPlayer.braceRight.transform);
                //left
                Instantiate(item.prefab[1], characterSlotModel.braceLeft.transform);
                Instantiate(item.prefab[1], characterSlotPlayer.braceLeft.transform);
                break;
            case ItemType.Shoulder:
                //right
                Instantiate(item.prefab[0], characterSlotModel.shoulderRight.transform);
                Instantiate(item.prefab[0], characterSlotPlayer.shoulderRight.transform);
                //left
                Instantiate(item.prefab[1], characterSlotModel.shoulderLeft.transform);
                Instantiate(item.prefab[1], characterSlotPlayer.shoulderLeft.transform);
                break;
            //case ItemType.Armor:
            //    Instantiate(item.prefab, characterSlot..transform);
            //    break;
            case ItemType.Helmet:
                Instantiate(item.prefab[0], characterSlotModel.helmet.transform);
                Instantiate(item.prefab[0], characterSlotPlayer.helmet.transform);
                break;
            case ItemType.Sheild:
                Instantiate(item.prefab[0], characterSlotModel.weaponLeft.transform);
                Instantiate(item.prefab[0], characterSlotPlayer.weaponLeft.transform);
                break;
        }
    }

    public void RemoveItemModel(Item item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                Destroy(characterSlotModel.weaponRight.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.weaponRight.transform.GetChild(0).gameObject);
                break;
            case ItemType.Bracer:
                //right
                Destroy(characterSlotModel.braceRight.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.braceRight.transform.GetChild(0).gameObject);
                //left
                Destroy(characterSlotModel.braceLeft.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.braceLeft.transform.GetChild(0).gameObject);
                break;
            case ItemType.Shoulder:
                //right
                Destroy(characterSlotModel.shoulderRight.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.shoulderRight.transform.GetChild(0).gameObject);
                //left
                Destroy(characterSlotModel.shoulderLeft.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.shoulderLeft.transform.GetChild(0).gameObject);
                break;
            //case ItemType.Armor:
            //    Instantiate(item.prefab, characterSlot..transform);
            //    break;
            case ItemType.Helmet:
                Destroy(characterSlotModel.helmet.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.helmet.transform.GetChild(0).gameObject);
                break;
            case ItemType.Sheild:
                Destroy(characterSlotModel.weaponLeft.transform.GetChild(0).gameObject);
                Destroy(characterSlotPlayer.weaponLeft.transform.GetChild(0).gameObject);
                break;
        }
    }

}
