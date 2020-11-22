using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;
    public bool isjumping;
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private float timeground;

    private float referencetime;

    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        referencetime = timeground;
    }

    void Update()
    {
        Move();
        
        // coyote time
        if(!isjumping)
        {
            timeground = referencetime;
            Jump();
        }
        else
        {
            Jump();
            timeground -= Time.deltaTime; 
        }
    }

    //flip player and move horizontal
    void Move()
    {
        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3 (0f,0f,0f);
        }

         if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3 (0f,180f,0f);
        }

         if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("run", false);
        }
    }

    //jump player
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && timeground > 0)
        {
               //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
               rb.velocity =  new Vector3 (rb.velocity.x, jumpForce, 0f);
               anim.SetBool("jump", true);  
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isjumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "morreu")
       {
           GameController.instance.Gameoverr();
           Destroy(gameObject);
           
       } 
    }

    void OnCollisionExit2D (Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isjumping = true;
        }
    }
}
