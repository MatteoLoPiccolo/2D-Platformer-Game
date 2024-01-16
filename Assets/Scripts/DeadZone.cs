using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] Transform _startLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit dead zone!");

            if (_playerController != null)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}