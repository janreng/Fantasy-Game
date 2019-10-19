using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero Stats", menuName = "Hero/Hero Stats")]
public class HeroStats : ScriptableObject
{
    public int id;
    public double damage;
    public double armor;
    public double health;
    public CharacterType type;
}
