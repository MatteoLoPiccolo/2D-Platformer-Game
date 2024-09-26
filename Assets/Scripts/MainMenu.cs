using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _levelPopup;
    [SerializeField] Button _startButton;
    [SerializeField] Button _quitButton;

    // Start is called before the first frame update
    void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        _levelPopup.SetActive(true);
        SoundManager.Instance.PlaySound(SoundManager.SoundsType.ButtonClick, "MenuButtonStart");
    }

    private void QuitGame()
    {
        Application.Quit();
        SoundManager.Instance.PlaySound(SoundManager.SoundsType.ButtonClick, "MenuButtonBack");
        Debug.Log("Quit from application");
    }
}