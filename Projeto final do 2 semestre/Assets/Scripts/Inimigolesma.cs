using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigolesma : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Animator anim;

    [SerializeField]
    public bool coll;
    
    [SerializeField]
    public LayerMask layer;

    [SerializeField]
    public Transform head;

    [SerializeField]
    public Transform left;

    [SerializeField]
    public Transform right;

    [SerializeField]
    public float speed;

    [SerializeField]
    public BoxCollider2D box;

    [SerializeField]
    public CircleCollider2D circle;

    bool playermuerto = false;
    
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rigi.velocity = new Vector2 (speed, rigi.velocity.y);
        coll = Physics2D.Linecast(left.position, right.position, layer);

        if(coll)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed = -speed;
        }
    }
    
    private void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            float cabpont = other.contacts[0].point.y - head.position.y;
            Debug.Log(cabpont);

            if(cabpont > 0 && !playermuerto)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                anim.SetTrigger("deadlesm");
                box.enabled = false;
                circle.enabled = false;
                rigi.bodyType = RigidbodyType2D.Kinematic;
                GetComponent<AudioSource>(). Play();
                Destroy(gameObject, 0.25f);
            }
            else
            {
                playermuerto = true;
                GameController.instance.Gameoverr();
                Destroy(other.gameObject);
            }
        }
    }
}
