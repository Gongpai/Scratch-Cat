using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Character2DController : MonoBehaviour
{
    [SerializeField] private int m_speed = 4;
    [SerializeField] private int m_jumpHight = 4;
    [SerializeField] private Vector2 GroundedOffset;
    [SerializeField] private float m_radius;
    [SerializeField] private LayerMask GroundLayers;

    private bool isRun;
    private bool Grounded;
    private bool isJump;
    
    //System
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    //Animation ID
    protected int _animIDSpeed;
    protected int _animIDGrounded;
    protected int _animIDJump;

    public Rigidbody2D rigidbody2D
    {
        get => _rigidbody2D;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        AssignAnimationIDs();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            OnRun(1);
        if(Input.GetKey(KeyCode.A))
            OnRun(-1);
        
        if(Input.GetKeyDown(KeyCode.Space) && Grounded)
            OnJump();

        OnGrounded();
        AutoFlipSprite();
        Animation();
    }
    
    protected void AssignAnimationIDs()
    {
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDSpeed = Animator.StringToHash("Speed");
    }
    
    private void OnRun(int direction)
    {
        _rigidbody2D.velocity = new Vector2((Vector2.right * direction * m_speed * 0.25f).x, _rigidbody2D.velocity.y);
        //transform.Translate(transform.right * m_speed * direction * Time.deltaTime);
    }

    private void AutoFlipSprite()
    {
        //print($"Right : {new Vector2(_rigidbody2D.velocity.x, 0).normalized}");
        
        if(new Vector2(_rigidbody2D.velocity.x, 0).normalized.x < 0)
            _spriteRenderer.flipX = true;
        else if (new Vector2(_rigidbody2D.velocity.x, 0).normalized.x > 0)
            _spriteRenderer.flipX = false;
    }

    private void OnJump()
    {
        _rigidbody2D.AddForce(transform.up * m_jumpHight, ForceMode2D.Impulse);
        isJump = true;
    }

    private void Animation()
    {
        //print($"Float : {new Vector2(_rigidbody2D.velocity.x, 0).magnitude} || Int : {Mathf.CeilToInt(new Vector2(_rigidbody2D.velocity.x, 0).magnitude)}");
        _animator.SetInteger(_animIDSpeed, Mathf.CeilToInt(new Vector2(_rigidbody2D.velocity.x, 0).magnitude));
        _animator.SetBool(_animIDJump, isJump);
        _animator.SetBool(_animIDGrounded, Grounded);
    }

    private void OnGrounded()
    {
        Vector3 spherePosition = new Vector3(transform.position.x - GroundedOffset.x,
            transform.position.y - GroundedOffset.y, transform.position.z);
        Grounded = Physics2D.CircleCast(spherePosition, m_radius, Vector2.down, m_radius, GroundLayers);

        if (Grounded)
        {
            isJump = false;
        }
        else
            isJump = true;
    }
    
    protected virtual void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (Grounded) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(
            new Vector3(transform.position.x - GroundedOffset.x, transform.position.y - GroundedOffset.y, transform.position.z),
            m_radius);
    }
}
