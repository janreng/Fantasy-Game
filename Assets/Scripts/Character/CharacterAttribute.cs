using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttribute : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField] public int level;
    [SerializeField] public float exp;
    [SerializeField] public float totalExp;
    [SerializeField] public double damage, armor, health;
    [SerializeField] public CharacterType type;
}
