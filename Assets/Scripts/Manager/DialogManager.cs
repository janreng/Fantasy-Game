using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    [SerializeField] Image[] slots;
    [SerializeField] GameObject objItems;
    [SerializeField] Text content;
    [SerializeField] RawImage avatar;
    [SerializeField] Button btnContinue;
    public List<Item> items = new List<Item>();

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
        HideAllIcon();
        btnContinue.onClick.AddListener(() => CompleteDialog());
    }

    public void CompleteDialog()
    {
        UIPlayManager.instance.isOpenUI = false;
        gameObject.SetActive(false);
        if(items.Count > 0)
        {
            foreach (Item item in items)
            {
                InventoryManager.instance.AddItem(item);
            }
        }
        ResetDialog();
        QuestManager.instance.CompleteQuest();
        QuestManager.instance.RemoveQuestComplete();
    }

    public void SetIconItem(int index, Sprite item)
    {
        slots[index].sprite = item;
    }

    public void SetContent(string strContent)
    {
        content.text = strContent;
    }

    public void ShowIconToItemCount()
    {
        for(int i = 0; i < items.Count; i++)
        {
            slots[i].transform.parent.gameObject.SetActive(true);
        }
    }

    public void HideAllIcon()
    {
        foreach(var icon in slots)
        {
            icon.transform.parent.gameObject.SetActive(false);
        }
    }

    void ResetDialog()
    {
        items.Clear();
        HideAllIcon();
    }

}
