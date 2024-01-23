using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] List<Button> levelButtons = new List<Button>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (var button in levelButtons)
        {
            button.onClick.AddListener(() => LoadLevel((Level)levelButtons.IndexOf(button) + 1));
        }
    }

    private void LoadLevel(Level level)
    {
        if (SceneManager.GetSceneByBuildIndex((int)level) != null)
        {
            SceneManager.LoadScene((int)level);
        }
        else
        {
            Debug.LogWarning($"Scene {level} not found.");
        }
    }

}
