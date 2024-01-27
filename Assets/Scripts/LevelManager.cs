using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager  : MonoBehaviour 
{
    [SerializeField] List<string> levels = new List<string>();

    private static LevelManager _instance;

    public static LevelManager Instance {  get { return _instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }

    void Start()
    {
        if (GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentSceneIndex = levels.FindIndex(level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < levels.Count)
            SetLevelStatus(levels[nextSceneIndex], LevelStatus.Completed);
    }

    public LevelStatus GetLevelStatus(string levelName)
    {
        var levelStatus = (LevelStatus)PlayerPrefs.GetInt(levelName, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName, (int)levelStatus);
    }
}