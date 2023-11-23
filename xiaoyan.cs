using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaoyan : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    public float groundDrag;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    float horizontalInput;
    float verticalInput;
    AudioSource m_AudioSource;
    Vector3 moveDirection;
    Rigidbody rb;
    bool isRun = false;
    private Animator anim;
    public bool isMove;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        anim.SetBool("isRun", isRun);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        SpeedControl();
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


    }
    private void FixedUpdate()
    {
        Run();
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        bool hasHoriziontal = !Mathf.Approximately(horizontalInput, 0.0f);
        bool hasVertical = !Mathf.Approximately(verticalInput, 0.0f);
        isMove = hasHoriziontal || hasVertical;
        if (isMove)
        {
            isRun = true;
            anim.SetBool("isRun", isRun);
            if (!m_AudioSource.isPlaying) {
                m_AudioSource.Play();
            }
            
        }
        else
        {
            isRun = false;
            m_AudioSource.Stop();
        }
    }
    private void SpeedControl()
    {
        
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y,limitedVel.z);
        }
    }
    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
            m_AudioSource.pitch = 1f;
        }
        else
        {
            moveSpeed = 3f;
            m_AudioSource.pitch = 0.75f;
        }
    }
}
