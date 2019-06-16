using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomEditor : EditorWindow
{
    [MenuItem("Fantasy/Reset Quest")]
    public static void ResetQuest()
    {
        Debug.Log("Clear");
    }
}
