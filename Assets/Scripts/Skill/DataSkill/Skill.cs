using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "SkillSet/Skill")]
public class Skill : ScriptableObject
{
    public string name;
    public string description;
    public float cooldown;
    public double damage;
    public SkillType skillType;
    public Sprite icon;
    public GameObject effect;
}
