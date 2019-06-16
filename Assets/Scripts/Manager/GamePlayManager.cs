using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    public static string GIVE_ITEM = "Bạn nhận được ";
    public static string CANT_NOT_EQUIPMENT = "Không thể trang bị ";
    public static string EQUIPMENT = "Trang bị ";

    GameController gameController;

    [SerializeField] Transform character;
    [SerializeField] Transform modelStats;
    [SerializeField] PlayerController playerController;

    CharacterAttribute characterAttribute;

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
        StatsManager.instance.OnEquipped += AddCharacterAttribute;
        StatsManager.instance.OnRemoveEquipment += RemoveCharacterAttribute;
        GameController.instance.HidePanelLoading();
        InitCharacter();
    }

    void InitCharacter()
    {
        InitPlayer();
        InitCharacterStats();
        //set stats
        StatsManager.instance.SetStats(characterAttribute);
        UIPlayManager.instance.SetNameAndLevel(characterAttribute.name, characterAttribute.level.ToString());
    }

    // init player
    void InitPlayer()
    {
        GameObject playerInit = GameController.instance.InitCharacter();
        playerInit.transform.SetParent(character);
        playerInit.transform.localPosition = Vector3.zero;
        characterAttribute = playerInit.GetComponent<CharacterAttribute>();
        switch (characterAttribute.type)
        {
            case CharacterType.Archer:
                playerInit.GetComponent<CharacterSkill>().skills = GameController.instance.archerSkills;
                break;
            case CharacterType.Sword:
                playerInit.GetComponent<CharacterSkill>().skills = GameController.instance.swordSkills;
                break;
            case CharacterType.Axe:
                playerInit.GetComponent<CharacterSkill>().skills = GameController.instance.axeSkills;
                break;
        }
        SkillManager.instance.SetSkill(playerInit.GetComponent<CharacterSkill>().skills);
        playerController.SetComponentCharacter(playerInit.GetComponent<CharacterAnimator>(), characterAttribute);
        StatsManager.instance.characterPlayer = playerInit;
    }

    // init character stats
    void InitCharacterStats()
    {
        GameObject characterInit = GameController.instance.InitCharacter();
        characterInit.transform.SetParent(modelStats);
        characterInit.transform.localPosition = Vector3.zero;
        characterInit.transform.localRotation = Quaternion.Euler(0, 0, 0);
        characterInit.transform.localScale = new Vector3(1, 1, 1);
        StatsManager.instance.characterStats = characterInit;
    }

    public void AddCharacterAttribute(Item item)
    {
        characterAttribute.damage += item.damage;
        characterAttribute.armor += item.defense;
        characterAttribute.health += item.health;
        StatsManager.instance.SetStats(characterAttribute);
    }

    public void RemoveCharacterAttribute(Item item)
    {
        characterAttribute.damage -= item.damage;
        characterAttribute.armor -= item.defense;
        characterAttribute.health -= item.health;
        StatsManager.instance.SetStats(characterAttribute);
    }

    public CharacterType GetClassCharacter()
    {
        return characterAttribute.type;
    }

    public int GetLevelCharacter()
    {
        return characterAttribute.level;
    }

    public void SetExpBonus(float exp)
    {
        characterAttribute.exp += exp;
        characterAttribute.totalExp += exp;
        if (characterAttribute.exp < ExpManager.instance.GetExpCurrentLevel(characterAttribute.level))
            ExpManager.instance.SetUIExpGive(characterAttribute.exp, ExpManager.instance.GetExpCurrentLevel(characterAttribute.level));
        else
        {
            while(characterAttribute.exp >= ExpManager.instance.GetExpCurrentLevel(characterAttribute.level))
            {
                characterAttribute.exp -= ExpManager.instance.GetExpCurrentLevel(characterAttribute.level);
                characterAttribute.level += 1;
                Debug.Log("exp" + characterAttribute.exp);
                UIPlayManager.instance.LevelUp(characterAttribute.level);
                StatsManager.instance.LevelUp(characterAttribute.level);
            }
            ExpManager.instance.SetUIExpGive(characterAttribute.exp, ExpManager.instance.GetExpCurrentLevel(characterAttribute.level));
            ExpManager.instance.PlayEffectLevelUp();
        }

    }

}
