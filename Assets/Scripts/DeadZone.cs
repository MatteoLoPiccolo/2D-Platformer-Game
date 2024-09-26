using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerController != null)
            {
                _playerController.Die();
            }
        }
    }
}