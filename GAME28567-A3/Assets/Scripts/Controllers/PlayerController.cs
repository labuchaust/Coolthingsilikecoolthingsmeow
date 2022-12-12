using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Your solution must make use of the following fields. If these values are changed, even at runtime,
    /// the character controller should respect the new values and act as detailed in the Unity inspector.
    /// </summary>

    public BoxCollider2D box;
    public LayerMask groundCheck;
    public LayerMask player;
    public Rigidbody2D coolb;
    public Transform feet;
   

    [SerializeField]
    private float m_jumpApexHeight;

    [SerializeField]
    private float m_jumpApexTime;

    [SerializeField]
    private float m_terminalVelocity;

    [SerializeField]
    private float m_coyoteTime;

    [SerializeField]
    private float m_jumpBufferTime;

    [SerializeField]
    private float m_accelerationTimeFromRest;

    [SerializeField]
    private float m_decelerationTimeToRest;

    [SerializeField]
    private float m_maxHorizontalSpeed;

    [SerializeField]
    private float m_accelerationTimeFromQuickturn;

    [SerializeField]
    private float m_decelerationTimeFromQuickturn;

    public enum FacingDirection { Left, Right }

    FacingDirection dirL;
    FacingDirection dirR;



    public bool IsWalking()
    {
       if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Debug.Log("aaaaaaaaaa");
            return true;
        } 
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Debug.Log("eeeeeeeeeeeeeee");
            return true;
        }
       else
        {
            return false;
        }
     // throw new System.NotImplementedException( "IsWalking in PlayerController has not been implemented." );
    }

    public bool IsGrounded()
    {

        Collider2D ground = Physics2D.OverlapCircle(feet.position, 0.5f, groundCheck);
        if (ground != null)
        {
            Debug.Log("true");
            return true;
        }

      

        return false;

      

       // throw new System.NotImplementedException( "IsGrounded in PlayerController has not been implemented." );
    }

    public FacingDirection GetFacingDirection()
    {


        if (Input.GetAxisRaw("Horizontal") < 0)
        { dirR = FacingDirection.Left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
            {

            dirR = FacingDirection.Right;
            
        }
        return dirR;






        // throw new System.NotImplementedException("GetFacingDirection in PlayerController has not been implemented.");
    }

    // Add additional methods such as Start, Update, FixedUpdate, or whatever else you think is necessary, below.

    Rigidbody2D rb;
    float jumpForce;

    private void Start()
    {
        
        dirR = FacingDirection.Right;
        FacingDirection myDirection;

        myDirection = FacingDirection.Right;

        rb = GetComponent<Rigidbody2D>();
        


    }
    private void Update()
    {

        IsWalking();
        GetFacingDirection();
       
        coolb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * m_maxHorizontalSpeed, coolb.velocity.y);


        if (ShovelKnightInput.IsJumpPressed())
        {
            if(IsGrounded())
            {
                Debug.Log("time" + Time.realtimeSinceStartup);
                rb.AddForce(Vector2.up * m_jumpApexTime, ForceMode2D.Force);


                //we can put jump
                //find out when player gets to apex
                //push player down with negative AddForce and stop when isGrounded is true (--> Vector.Down *m_jumpapextime, forcemode2d.force)
            }
        }

        //if (IsGrounded())
        //{
        //    if (Input.GetButtonDown("Jump"))
        //    {
        //        Debug.Log("Duration in seconds" + Time.realtimeSinceStartup);
        //    }
          
        //}

    }
    
}


// if (isGrounded == true){ can jump if keycode(jump) } + coyote time
// addforce new vector2 (something, jumpapexheight)
