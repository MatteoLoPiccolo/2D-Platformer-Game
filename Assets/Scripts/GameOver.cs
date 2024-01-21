using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _gameOverObject;
    [SerializeField] Button _restartButton;
    [SerializeField] Button _mainMenuButton;

    // Start is called before the first frame update
    void Awake()
    {
        _gameOverObject.SetActive(false);

        _restartButton.onClick.AddListener(RestartLevel);
        _mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
