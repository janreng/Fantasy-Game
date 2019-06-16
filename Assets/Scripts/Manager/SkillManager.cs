using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    [SerializeField] SkillSlot[] skillSlots;
    [SerializeField] Transform character;

    CharacterAnimator characterAnimator;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void SetSkill(Skill[] skills)
    {
        for(int i = 0; i < skillSlots.Length; i++)
        {
            skillSlots[i].AddSkill(skills[i]);
        }
    }

    public void ClickSkill()
    {
        if (characterAnimator == null)
            characterAnimator = character.GetComponentInChildren<CharacterAnimator>();
        characterAnimator.PlayAnimAttack();
    }
}
