using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayManager : MonoBehaviour
{
    public static UIPlayManager instance;
    [SerializeField] GameObject panelStats;
    [SerializeField] GameObject panelDialog;
    [SerializeField] GameObject panelInventory;
    [SerializeField] GameObject panelDetail;
    [SerializeField] GameObject panelTool;
    [SerializeField] GameObject panelSkill;
    [Header("Info")]
    [SerializeField] GameObject panelInfo;
    [SerializeField] Text txtLevel;
    [SerializeField] Text txtName;
    [SerializeField] Button btnBag;
    [SerializeField] Button btnConvert;



    public bool isOpenUI = false;
    Camera cam;

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
        cam = Camera.main;
        btnBag.onClick.AddListener(() => ShowStatsCharacter());
        SetUIInit();
    }

    void ShowStatsCharacter()
    {
        panelStats.SetActive(true);
        panelInventory.SetActive(true);
        isOpenUI = true;
    }

    public void HideStatsCharacter()
    {
        panelStats.SetActive(false);
        panelInventory.SetActive(false);
        isOpenUI = false;
    }

    public void ShowDialog(CharacterType type, Quest quest)
    {
        isOpenUI = true;
        panelDialog.SetActive(true);
        DialogManager.instance.SetContent(quest.description);
        for (int i = 0; i < quest.items.Length; i++)
        {
            DialogManager.instance.items.Add(quest.items[i]);
            DialogManager.instance.SetIconItem(i, quest.items[i].icon);
        }
        DialogManager.instance.ShowIconToItemCount();
    }

    public void SetNameAndLevel(string name, string level)
    {
        txtName.text += name;
        txtLevel.text = level;
    }

    public void ShowPanelDetail()
    {
        panelDetail.SetActive(true);
        DetailItemManager.instance.ResetButton();
    }

    public void HidePanelDetail()
    {
        panelDetail.SetActive(false);
    }

    void SetIconWeapon(Sprite weapon)
    {
        panelDialog.GetComponent<DialogManager>().SetIconItem(0, weapon);
    }


    void SetUIInit()
    {
        panelInventory.SetActive(false);
        panelDialog.SetActive(false);
        panelStats.SetActive(false);
        panelDetail.SetActive(false);
    }

    public void LevelUp(int levelUp)
    {
        txtLevel.text = levelUp.ToString();
    }

    public void ClickBtnConvert()
    {
        btnConvert.GetComponent<Animator>().SetTrigger("isClick");
        panelTool.SetActive(!panelTool.activeSelf);
        panelSkill.SetActive(!panelSkill.activeSelf);
    }
}
