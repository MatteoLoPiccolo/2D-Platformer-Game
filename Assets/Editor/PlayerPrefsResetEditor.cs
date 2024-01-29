#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class PlayerPrefsResetEditor : MonoBehaviour
{
    [MenuItem("Tools/Reset PlayerPrefs")]
    private static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs reset!");
    }
}
#endif