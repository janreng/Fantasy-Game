using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum CharacterType
{
    Archer,
    Sword,
    Axe,
    None
}

public enum ItemType
{
    Weapon,
    Armor,
    Helmet,
    Sheild,
    Shoulder,
    Bracer,
}

public enum SkillType
{
    Proactive,
    Passive
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] Image slider;
    [SerializeField] GameObject panelLoading;
    [SerializeField] Text txtProgress;

    [Header("Character")]
    [SerializeField] GameObject[] characterNoobs;
    public CharacterAttribute characterAttribute;

    [Header("Skill")]
    [SerializeField] public Skill[] archerSkills;
    [SerializeField] public Skill[] swordSkills;
    [SerializeField] public Skill[] axeSkills;

    AsyncOperation async;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //characterAttribute = characterNoob.GetComponent<CharacterAttribute>();
    }

    public IEnumerator LoadSceneAsync(string name)
    {
        Debug.Log("Load scene " + name);
        panelLoading.SetActive(true);
        async = SceneManager.LoadSceneAsync(name);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.fillAmount = async.progress;
            txtProgress.text = slider.fillAmount * 100 + "%";
            if (async.progress == 0.9f)
            {
                slider.fillAmount = 1f;
                txtProgress.text = slider.fillAmount * 100 + "%";
                yield return new WaitForSeconds(1f);
                async.allowSceneActivation = true;
            }
        }
    }

    public void SetAttribute(CharacterAttribute attribute)
    {
        if(attribute.type == CharacterType.Archer)
            characterAttribute = characterNoobs[0].GetComponent<CharacterAttribute>();
        else
            characterAttribute = characterNoobs[1].GetComponent<CharacterAttribute>();

        Debug.Log("Set Attribute");
        characterAttribute.name = attribute.name;
        characterAttribute.level = attribute.level;
        characterAttribute.damage = attribute.damage;
        characterAttribute.armor = attribute.armor;
        characterAttribute.health = attribute.health;
        characterAttribute.type = attribute.type;
    }

    public GameObject InitCharacter()
    {
        Debug.Log("Init character");
        switch (characterAttribute.type)
        {
            case CharacterType.Archer:
                return Instantiate(characterNoobs[0], new Vector3(0, 10f, 0), Quaternion.identity);
            case CharacterType.Sword:
                return Instantiate(characterNoobs[1], new Vector3(0, 10f, 0), Quaternion.identity);
            case CharacterType.Axe:
                return Instantiate(characterNoobs[2], new Vector3(0, 10f, 0), Quaternion.identity);
        }
        return null;
    }

    public void HidePanelLoading()
    {
        panelLoading.SetActive(false);
    }
}
