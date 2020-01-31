using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;

     Rigidbody2D rb;
    public float jumpSpeed = 10.0f;

    public float speed = 10.0f;

    public float walkAcc = 1.2f;

    Vector2 velocity;

    bool canJump = true;

     LayerMask mask;
     
     private bool grounded = false;
     
    void Awake() {
        
    rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {

       mask = LayerMask.GetMask("Environment");
       velocity = new Vector2(0.0f, 0.0f);

    }

    void FixedUpdate() {
        
        Debug.Log(grounded);

        if(grounded)
        {

            velocity.y = 0.0f;

        if(Input.GetButton("Vertical"))
        {
            Debug.Log("Jump button pressed");
          //  rb.AddForce(new Vector2(0.0f, jumpForce));#
       //     velocity.y = Mathf.Sqrt(2 * jumpSpeed * Mathf.Abs(Physics2D.gravity.y));
            velocity.y = jumpSpeed;
            grounded = false;
        }
        }

        float horInput = Input.GetAxisRaw("Horizontal");
        //velocity.x = Mathf.MoveTowards(velocity.x, speed * horInput, walkAcc * Time.deltaTime);
        velocity.x = speed * horInput;

        transform.Translate(velocity * Time.deltaTime);

        
      // Debug.Log(canJump);

        if(!grounded)
        {
       //     RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f, mask);
            	Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, mask);

            for(int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].gameObject != gameObject)
                {
                    grounded = true;
                }                   
            }

            /*
            if(hit.collider != null)
            {              
                grounded = true;
               // Debug.Log("Setting jump to true");
                canJump = true;
            }*/
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
