﻿using System.Collections.Generic;
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
            var levelStatus = LevelManager.Instance.GetLevelStatus(level.ToString());

            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Cannot play this level until you unlock it.");
                    break;
                case LevelStatus.Unlocked:
                    SoundManager.Instance.PlaySound(SoundManager.SoundsType.ButtonClick);
                    SceneManager.LoadScene((int)level);
                    Debug.Log("load : " + level.ToString());
                    break;
                case LevelStatus.Completed:
                    SoundManager.Instance.PlaySound(SoundManager.SoundsType.ButtonClick);
                    SceneManager.LoadScene(level.ToString());
                    break;
            }
        }
        else
        {
            Debug.LogWarning($"Scene {level} not found.");
        }
    }
}