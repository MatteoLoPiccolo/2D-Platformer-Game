using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;

    private bool _isJumping;
    private const float standingOffsetX = 0.015f;
    private const float standingOffsetY = 1f;
    private const float standingSizeX = 0.7f;
    private const float standingSizeY = 2.13f;
    
    private const float crouchingOffsetX = -0.11f;
    private const float crouchingOffsetY = 0.6f;
    private const float crouchingSizeX = 0.94f;
    private const float crouchingSizeY = 1.36f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        FlipSprite(horizontalInput);
        MovePlayer(horizontalInput, verticalInput);

        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        _animator.SetFloat("Height", verticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _animator.SetBool("IsCrouching", true);

            _boxCollider2D.size = new Vector2(crouchingSizeX, crouchingSizeY);
            _boxCollider2D.offset = new Vector2(crouchingOffsetX, crouchingOffsetY);
        } 
        else
        {
            _animator.SetBool("IsCrouching", false);

            _boxCollider2D.size = new Vector2(standingSizeX, standingSizeY);
            _boxCollider2D.offset = new Vector2(standingOffsetX, standingOffsetY);
        }

    }

    void MovePlayer(float horizontal, float vertical)
    {
        var position = transform.position;
        position.x += (horizontal * _speed) * Time.deltaTime;
        transform.position = position;

        if (vertical > 0 && !_isJumping)
        {
            _isJumping = true;
            _animator.SetBool("IsJumping", true);
        }
    }

    void OnJumpAnimationEnd()
    {
        _isJumping = false;
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
}