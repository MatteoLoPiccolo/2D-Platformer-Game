using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _health;
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    [SerializeField] Transform _lookDirection;
    [SerializeField] float _maxAttackDistance;
    [SerializeField] bool _isAttacking;

    [SerializeField] Transform _checkForGround;
    [SerializeField] PlayerController _playerController;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
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

    private void Attack()
    {
        if (_playerController != null)
        {
            Vector3 raycastOrigin = _lookDirection.position;
            Vector3 directionToPlayer = _playerController.transform.position - raycastOrigin;
            LayerMask layerMask = LayerMask.GetMask("Player");

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, directionToPlayer, _maxAttackDistance, layerMask);

            if (hit.collider != null)
            {
                float distanceToPlayer = Vector3.Distance(raycastOrigin, _playerController.transform.position);

                if (distanceToPlayer <= _maxAttackDistance)
                {
                    _isAttacking = true;
                    _animator.SetBool("IsAttacking", true);
                }
            }
        }
    }

    public void OnAttackEnd()
    {
        _isAttacking = false;
        _animator.SetBool("IsAttacking", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerController != null)
            {
                Debug.Log("Enemy hit the player!");
                _playerController.TakeDamage(_damage);
            }
        }
    }
}