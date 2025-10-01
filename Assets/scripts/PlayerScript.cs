using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    HelperScript helper;

    public float health = 5, maxHealth = 5;

    [SerializeField] private HealthBarUI healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    float xv, yv;
    public Animator anim;
    bool facingRight = true;
    private float horizontal;
    LayerMask groundLayerMask;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 1.402f;
        bool hitSomething = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;
    }
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();

        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }


   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h") && health < 5)
        {
            health += 1;

        }
        if (Input.GetKeyDown("g") && health > 0)
        {
            health -= 1;
        }
        if (Input.GetKeyDown("h"))
        {
            helper.HelloWorld();

        }



        xv = 0;
        yv = rb.linearVelocity.y;

        float speed = 5;
        float jumpHeight = 8;
        float runSpeed = 8;

        Debug.DrawRay(transform.position, Vector2.down * 0.9f, Color.red);


        if (Input.GetKeyDown(KeyCode.Space) && GetIsGrounded())
        {
            yv = jumpHeight;
        }
    
        
        if (Input.GetKey("d"))
        {
            if (ExtendedRayCollisionCheck(0.35f, 0.7f) == false)
            {
                xv = speed;

            }
     
        }
        if (Input.GetKey("d") && Input.GetKey(KeyCode.LeftShift))
        {
            if (ExtendedRayCollisionCheck(0.35f, 0.7f) == false)
            {
                xv = runSpeed;
            }


        }

        if (Input.GetKey("a"))
        {
            if (ExtendedRayCollisionCheck(-0.35f, 0.7f) == false)
            {
                xv = -speed;

            }
    
        }

        if (Input.GetKey("a") && Input.GetKey(KeyCode.LeftShift))
        {
            if (ExtendedRayCollisionCheck(-0.35f, 0.7f) == false)
            {
                xv = -runSpeed;
            }


        }



        rb.linearVelocity = new Vector3(xv, yv, 0);

        if(!facingRight && xv > 0)
        {
            Flip();
        }
        if (facingRight && xv < 0)
        {
            Flip();
        }
        if (xv >= 0.1f || xv <= -0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a"))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (yv > 0 && !GetIsGrounded())
        {
            anim.SetBool("isJumping", true);
        }
        if (yv < 0 && !GetIsGrounded())
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);

        }
        if (yv == 0 || GetIsGrounded())
        {
            anim.SetBool("isFalling", false);
        }

       // WallSlide();
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / health), 20), health + "/" + maxHealth);
    }

    private bool GetIsGrounded()
    {
       return Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Ground"));

    }





    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    /* private bool IsWalled()
      {
         if (xv < 0)
         {
             return ExtendedRayCollisionCheck(-0.35f, 0.65f);
         }
         if (xv > 0)
         {
             return ExtendedRayCollisionCheck(0.35f, 0.65f);
         }
         else
         {
             return false;
         }
     }

     private void WallSlide()
     {
         if (IsWalled() && !GetIsGrounded() && xv != 0)
         {
             isWallSliding = true;
             rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
         }
         else
         {
             isWallSliding = false;
         }
     }
    */
}

