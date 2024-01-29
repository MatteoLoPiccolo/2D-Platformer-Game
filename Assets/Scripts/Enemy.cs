using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _damage;

    [SerializeField] Transform _checkForGround;
    [SerializeField] PlayerController _playerController;

    private void Update()
    {
        Move();
        CheckForGround();
    }

    private void CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_checkForGround.position, Vector2.down, 3.0f);

        if (hit.collider == null)
        {
            ReverseDirectionAndSpeed();
        }
    }

    private void Move()
    {
        Vector3 movement = Vector3.right * _speed * Time.deltaTime;

        if (transform.localScale.x > 0)
            movement = Vector3.right * Mathf.Abs(_speed) * Time.deltaTime;
        else
            movement = Vector3.left * Mathf.Abs(_speed) * Time.deltaTime;

        transform.position += movement;
    }

    private void ReverseDirectionAndSpeed()
    {
        _speed *= -1;
        Flip();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");

            if (_playerController != null)
            {
                _playerController.Health -= _damage;

                if (_playerController.Health <= 0)
                {
                    _playerController.Die();
                }
            }
        }
    }
}