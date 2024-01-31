using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerController != null)
            {
                LevelManager.Instance.MarkCurrentLevelComplete();
                LevelManager.Instance.LoadNextUnlockedScene();
            }
        }
    }
}