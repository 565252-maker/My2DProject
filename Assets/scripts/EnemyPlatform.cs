using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class EnemyPlatform : MonoBehaviour
{
    public PlayerScript playerScript;
    HelperScript helper;

    float xv;
    bool facingRight = true;
    LayerMask groundLayerMask;
    Rigidbody2D rb;
    float yv;

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f;
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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xv = 2f;
        helper = gameObject.AddComponent<HelperScript>();

        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        //print("Enemy says: The player has " + playerScript.health + " lives");

        
            float yv = rb.linearVelocity.y;

        if (xv < 0)
        {
            if(ExtendedRayCollisionCheck(-0.35f, -0.2f) == false)
            {
                xv = -xv;
                Flip();
            }
        }
        if (xv > 0)
        {
            if (ExtendedRayCollisionCheck(0.35f, -0.2f) == false)
            {
                xv = -xv;
                Flip();
            }
        }

        rb.linearVelocity = new Vector3(xv, yv, 0);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
