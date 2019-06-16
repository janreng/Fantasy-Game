using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] GameObject cooldownObj;
    [SerializeField] Text txtCooldown;
    [SerializeField] Button btnSkill;

    Skill skill;
    float cooldown;

    private void Start()
    {
        btnSkill.onClick.AddListener(() => UseSkill());
    }

    public void AddSkill(Skill s)
    {
        skill = s;
        icon.sprite = s.icon;
    }

    public void UseSkill()
    {
        btnSkill.interactable = false;
        cooldownObj.SetActive(true);
        cooldown = skill.cooldown;
        txtCooldown.text = cooldown.ToString();
        InvokeRepeating("CooldownSkill", 1f, 1f);
    }

    void CooldownSkill()
    {
        if (cooldown > 0)
        {
            cooldown -= 1;
            txtCooldown.text = cooldown.ToString();
        }
        else
        {
            CancelInvoke();
            cooldownObj.SetActive(false);
            btnSkill.interactable = true;
        }
    }
}
