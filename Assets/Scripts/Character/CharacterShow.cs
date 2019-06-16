using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShow : MonoBehaviour
{
    public GameObject[] characters;
    //[SerializeField] ShowAttribute showAttribute;

    public void ShowCharacter(int index)
    {
        HideAllCharacter();
        characters[index].SetActive(true);
        SetTransformCharacter(characters[index]);

        //set attribute to show slide properties
        UIHomeManager.instance.SetCharacterAttribute(characters[index].GetComponent<CharacterAttribute>());
    }

    void HideAllCharacter()
    {
        foreach(var c in characters)
        {
            if(c.activeSelf)
                c.SetActive(false);
        }
    }

    void SetTransformCharacter(GameObject character)
    {
        character.transform.localPosition = new Vector3(1.5f, -2f, 95);
        character.transform.localRotation = Quaternion.LookRotation(Camera.main.transform.position, Vector3.up);
    }

    public GameObject GetCurrentCharacterSelect()
    {
        foreach (var obj in characters)
        {
            if (obj.activeSelf)
                return obj;
        }
        return null;
    }
}
