using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    public Text txtNameQuest;
    public Text txtDescription;

    private const string ENOUGH_LEVEL = "Yêu cầu level ";

    PlayerController playerController;
    Quest quest;

    public void AddQuest(Quest quest)
    {
        txtNameQuest.text = quest.name;
        if (quest.level > GameController.instance.characterAttribute.level)
        {
            txtDescription.text = ENOUGH_LEVEL + quest.level;
            txtDescription.color = Color.red;
        }
        else
        {
            txtDescription.text = quest.description;
            txtDescription.color = Color.white;
        }
        this.quest = quest;
    }

    public void ClearQuest()
    {
        quest = null;
        txtNameQuest.text = "";
        txtDescription.text = "";
    }

    public void MoveToReceivePlace()
    {
        QuestManager.instance.MoveToReceivePlace(quest.receivePlace);
        QuestManager.instance.currentQuest = quest;
    }

    public Quest QuestValue()
    {
        return quest;
    }

    public void UpdateDescription(int characterLevel)
    {
        if (quest.level <= characterLevel)
        {
            txtDescription.text = quest.description;
            txtDescription.color = Color.white;
        }
            
    }

}
