using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] PlayerController _playerController;

    void Start()
    {
        UpdateScore();
    }

    public void UpdatePoints(int value)
    {
        _playerController.Score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score : " + _playerController.Score.ToString();
        }
    }
}