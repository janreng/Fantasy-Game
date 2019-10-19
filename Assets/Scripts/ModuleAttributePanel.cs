using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleAttributePanel : MonoBehaviour
{
    [SerializeField] Slider sliderAttack, sliderArmor, sliderHealth;

    void Start()
    {
        this.RegisterListener(EventID.SelectHero, (param) => HandleAttribute( (CharacterAttribute) param));
    }

    //void Update()
    //{
    //    if (characterAttribute != null)
    //    {
    //        if (sliderAttack.value < characterAttribute.damage / 10)
    //            sliderAttack.value += 0.01f;
    //        if (sliderAttack.value > characterAttribute.damage / 10)
    //            sliderAttack.value -= 0.01f;
    //        if (sliderArmor.value < characterAttribute.armor / 10)
    //            sliderArmor.value += 0.01f;
    //        if (sliderArmor.value > characterAttribute.armor / 10)
    //            sliderArmor.value -= 0.01f;
    //        if (sliderHealth.value < characterAttribute.health / 100)
    //            sliderHealth.value += 0.01f;
    //        if (sliderHealth.value > characterAttribute.health / 100)
    //            sliderHealth.value -= 0.01f;
    //    }
    //}

    void HandleAttribute(CharacterAttribute characterAttribute)
    {

    }
}
