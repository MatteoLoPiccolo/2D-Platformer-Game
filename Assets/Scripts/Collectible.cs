using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] ScoreUI _scoreUI;
    [SerializeField] private int _points;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player grab collectible");

            if (_playerController != null)
            {
                _scoreUI.UpdatePoints(_points);
                Destroy(gameObject);
            }
        }
    }
}