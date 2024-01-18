using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit end level trigger!");

            if (_playerController != null)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}