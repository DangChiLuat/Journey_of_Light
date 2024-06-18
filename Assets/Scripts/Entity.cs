using System.Collections;
using UnityEngine;


public class Entity : MonoBehaviour
{

    #region Components
    // dieu khien animation cua nhan vat
    public Animator anim { get; private set; }
    // dieu hien vat ly
    public Rigidbody2D rb { get; private set; }
    // kieu khien hieu ung
    public SpriteRenderer sr { get; private set; }
    public CharacterStats stats { get; private set; }
    public CapsuleCollider2D cd {  get; private set; }
    #endregion

    [Header("Knockback info")]
    // Knockback info 
    // (Direction) huong knockBack khi bi tan cong
    [SerializeField] protected Vector2 knockbackPower = new Vector2(7,12);
    [SerializeField] protected Vector2 knockbackOffset = new Vector2(.5f,2);
    // (Duration) thoi gian bi knockBack 
    [SerializeField] protected float knockbackDuration = .07f;
    protected bool isKnocked;

    [Header("Collision info")]
    // huong tan cong
    public Transform attackCheck;
    // diem co the tan cong
    public float attackCheckRadius = 1.2f;
    // pham vi duoi check duoi can
    [SerializeField] protected Transform groundCheck;
    // khoang cach check
    [SerializeField] protected float groundCheckDistance = 1;
    // pham vi check tuong
    [SerializeField] protected Transform wallCheck;
    // khoang cach
    [SerializeField] protected float wallCheckDistance = .8f;
    // kiem tra xem co phai mat dat hay khong
    [SerializeField] protected LayerMask whatIsGround;


    // trang thai lat mat
    public int knockbackDir { get; private set; }
    
    // huong lat mat
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    public System.Action onFlipped;


    //protected virtual giup cac class khac co the goi khi ke thua tu entity
    protected virtual void Awake()
    {

    }

    // khoi tao 
    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        stats = GetComponent<CharacterStats>();
        cd = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    {

    }

    public virtual void SlowEntityBy(float _slowPercentage, float _slowDuration)
    {
        
    }

    protected virtual void ReturnDefaultSpeed()
    {
        anim.speed = 1;
    }
    // tao ham thuc hien knock back
    public virtual void DamageImpact() => StartCoroutine("HitKnockback");
 
    // huong bi knock back
    public virtual void SetupKnockbackDir(Transform _damageDirection)
    {
        if (_damageDirection.position.x > transform.position.x)
            knockbackDir = -1;
        else if (_damageDirection.position.x < transform.position.x)
            knockbackDir = 1;
    }

    public void SetupKnockbackPower(Vector2 _knockbackpower) => knockbackPower = _knockbackpower;

    // IEnumerator dung de tao ra ham coroutine cho phep thuc hien da luong
    protected virtual IEnumerator HitKnockback()
    {
        isKnocked = true;

        float xOffset = Random.Range(knockbackOffset.x, knockbackOffset.y);


        if(knockbackPower.x > 0 || knockbackPower.y > 0) // phayer chiu hieu qua cua knock back khi player bi danh trung
            rb.velocity = new Vector2((knockbackPower.x + xOffset) * knockbackDir, knockbackPower.y);

        yield return new WaitForSeconds(knockbackDuration);
        isKnocked = false;
        SetupZeroKnockbackPower();
    }

    protected virtual void SetupZeroKnockbackPower()
    {

    }
    // xet vat ly 
    #region Velocity
    public void SetZeroVelocity()
    {
        if (isKnocked)
            return;
        // dat van toc ve 0
        rb.velocity = new Vector2(0, 0);
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked)
            return;

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion
    #region Collision
    // groundCheckDistance khoang cach toi da 
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    protected virtual void OnDrawGizmos()
    {
        // DrawLine ve 1 duong thang
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
        // ve 1 hinh cau
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion
    // trang thai lat mat
    #region Flip
    public virtual void Flip()
    {
        // dao nguoc huong
        facingDir = facingDir * -1;
        // cap nhat lai trang lai neu facingDir true => false va nguoc lai
        facingRight = !facingRight;
        // doi huong
        transform.Rotate(0, 180, 0);

        if(onFlipped != null)
            onFlipped();
    }
    // xac dinh co can thiet phai lat mat khong
    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }

    public virtual void SetupDefailtFacingDir(int _direction)
    {
        facingDir = _direction;

        if (facingDir == -1)
            facingRight = false;
    }
    #endregion

    

    public virtual void Die()
    {

    }
}
