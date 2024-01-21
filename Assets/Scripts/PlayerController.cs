using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private int _score = 0;
    private int _health = 3;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded;

    private const float standingOffsetX = 0.015f;
    private const float standingOffsetY = 1f;
    private const float standingSizeX = 0.7f;
    private const float standingSizeY = 2.13f;

    private const float crouchingOffsetX = -0.11f;
    private const float crouchingOffsetY = 0.6f;
    private const float crouchingSizeX = 0.94f;
    private const float crouchingSizeY = 1.36f;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Jump");

        Move(horizontalInput);


        FlipSprite(horizontalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _animator.SetBool("IsCrouching", true);
            UpdateColliderSizeAndOffset(crouchingSizeX, crouchingSizeY, crouchingOffsetX, crouchingOffsetY);
        }
        else
        {
            _animator.SetBool("IsCrouching", false);
            UpdateColliderSizeAndOffset(standingSizeX, standingSizeY, standingOffsetX, standingOffsetY);
        }

        if (verticalInput > 0 && _isGrounded && horizontalInput == 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _isGrounded = false;
        _rigidbody2D.AddForce((Vector2.up * _jumpForce), ForceMode2D.Force);
        _animator.SetBool("IsJumping", true);
    }

    void Move(float horizontal)
    {
        var position = transform.position;
        position.x += (horizontal * _speed) * Time.deltaTime;
        _animator.SetFloat("Speed", Mathf.Abs(horizontal));
        transform.position = position;
    }

    void UpdateColliderSizeAndOffset(float sizeX, float sizeY, float offsetX, float offsetY)
    {
        _boxCollider2D.size = new Vector2(sizeX, sizeY);
        _boxCollider2D.offset = new Vector2(offsetX, offsetY);
    }

    void OnJumpAnimationEnd()
    {
        _isGrounded = true;
        _animator.SetBool("IsJumping", false);
    }

    void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = true;
            //Debug.Log("Ground");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            _isGrounded = false;
            //Debug.Log("Air");
        }
    }

    public void Die()
    {
        Debug.Log("Enemy killed me!");
        _animator.SetTrigger("Die");
    }
}