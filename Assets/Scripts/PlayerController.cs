using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        FlipSprite(horizontalInput);

        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
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