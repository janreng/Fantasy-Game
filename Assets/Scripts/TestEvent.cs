using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TestEvent : MonoBehaviour
{
    public Text textClick;
    string DATABASE_PATH = @"Assets/Data/weaponDB.asset";
    // Start is called before the first frame update
    void Start()
    {
        this.RegisterListener(EventID.OnClick, (param) => IncreaseValue());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//left mouse
        {
            Debug.Log("click");
            // code to Instantiate the bullet

            // raise shoot event
            this.PostEvent(EventID.OnClick);
            HeroStats stats = ScriptableObject.CreateInstance<HeroStats>();
            stats.damage = 10;
            AssetDatabase.CreateAsset(stats, DATABASE_PATH);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    void IncreaseValue()
    {
        int value = Int32.Parse(textClick.text);
        value++;
        textClick.text = value.ToString();

    }
}
