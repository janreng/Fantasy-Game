using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;

    [SerializeField] Transform pool;
    [SerializeField] GameObject textNotification;
    GameObject[] notificationPool;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        notificationPool = new GameObject[5];
        for (int i = 0; i < notificationPool.Length; i++)
        {
            GameObject noti = Instantiate(textNotification, pool);
            notificationPool[i] = noti;
            noti.SetActive(false);
        }

    }

    public void ShowNotification(string content)
    {
        foreach (var item in notificationPool)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.GetComponent<Text>().text = content;
                break;
            }
        }

    }

}
