using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    [SerializeField] Quest[] quests;
    [SerializeField] Transform questParent;
    [SerializeField] GameObject questPrefab;
    [SerializeField] PlayerController playerController;
    public Quest currentQuest;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        InitQuestNoneComplete();
        currentQuest = quests[0];
    }

    void InitQuestNoneComplete()
    {
        foreach (var quest in quests)
        {
            if (quest.state == false)
            {
                GameObject questInit = Instantiate(questPrefab, questParent);
                questInit.GetComponent<QuestSlot>().AddQuest(quest);
            }
        }
    }

    public void MoveToReceivePlace(Vector3 place)
    {
        playerController.MoveToMoveToReceivePlace(place);
    }

    public void CompleteQuest()
    {
        GamePlayManager.instance.SetExpBonus(currentQuest.exp);
        NotificationManager.instance.ShowNotification(GamePlayManager.GIVE_ITEM + currentQuest.exp + "EXP");
    }

    public void RemoveQuestComplete()
    {
        for(int i = 0; i < questParent.transform.childCount; i++)
        {
            if (questParent.GetChild(i).GetComponent<QuestSlot>().QuestValue() == currentQuest)
            {
                questParent.GetChild(i).gameObject.SetActive(false);
                questParent.GetChild(i).GetComponent<QuestSlot>().QuestValue().state = true;
                quests[i].state = true;
            }
            questParent.GetChild(i).GetComponent<QuestSlot>().UpdateDescription(GamePlayManager.instance.GetLevelCharacter());
        }
    }

}
