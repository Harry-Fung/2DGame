using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("The Layers which represent gameobjects that the Character Controller can be grounded on.")]
    public LayerMask groundedLayerMask;
    [Tooltip("The distance down to check for ground.")]
    public float groundedRaycastDistance = 0.1f;

    //Rigidbody2D m_Rigidbody2D;
    //CapsuleCollider2D m_Capsule;
    //Vector2 m_PreviousPosition;
    //Vector2 m_CurrentPosition;
    //Vector2 m_NextMovement;
    //ContactFilter2D m_ContactFilter;
    //RaycastHit2D[] m_HitBuffer = new RaycastHit2D[5];
    //RaycastHit2D[] m_FoundHits = new RaycastHit2D[3];
    //Collider2D[] m_GroundColliders = new Collider2D[3];
    //Vector2[] m_RaycastPositions = new Vector2[3];

    //public bool IsGrounded { get; protected set; }
    //public bool IsCeilinged { get; protected set; }
    //public Vector2 Velocity { get; protected set; }
    //public Rigidbody2D Rigidbody2D { get { return m_Rigidbody2D; } }
    //public Collider2D[] GroundColliders { get { return m_GroundColliders; } }
    //public ContactFilter2D ContactFilter { get { return m_ContactFilter; } }

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    public bool isJumping;
    public float jumpTimeCounter;
    public float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Awake()
    {

    }

    void Update()
    {
        //m_PreviousPosition = m_Rigidbody2D.position;
        //m_CurrentPosition = m_PreviousPosition + m_NextMovement;
        //Velocity = (m_CurrentPosition - m_PreviousPosition) / Time.deltaTime;

        //m_Rigidbody2D.MovePosition(m_CurrentPosition);
        //m_NextMovement = Vector2.zero;

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundedLayerMask);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }

        //CheckCapsuleEndCollisions();
        //CheckCapsuleEndCollisions(false);

        bool shoot = Input.GetButtonDown("Fire1");
        //shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }


    }
}
