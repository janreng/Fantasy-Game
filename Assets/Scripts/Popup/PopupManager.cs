using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] Text txtTitlePopup;
    [SerializeField] Button btnOK;

    private void Start()
    {
        btnOK.onClick.AddListener(() => HidePopup());
    }

    void HidePopup()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowPopup(string content)
    {
        this.gameObject.SetActive(true);
        txtTitlePopup.text = content;
    }
}
