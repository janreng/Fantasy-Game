using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    void OnDisable()
    {
        CancelInvoke();
    }

    void OnEnable()
    {
        Invoke("HideNotification", .5f);
    }

    void HideNotification()
    {
        this.gameObject.SetActive(false);
    }

}
