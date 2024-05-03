using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJump : MonoBehaviour
{
    public float direction;
   public bool walljumpAvailable;
    public Animator animator;
    


    bool left = false;
    float time;
    public float delaytime = 0.5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            animator.SetBool("wallkumpAvailable", true);

            left = false;
            RaycastHit2D hit;
            if(Physics2D.RaycastAll(transform.position,Vector3.right,2f).Length > 1)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            walljumpAvailable = true;

        }
        
    }
          

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            animator.SetBool("wallkumpAvailable", false);

            time = Time.time;
            left = true;

            direction = Mathf.Sign(collision.transform.position.x - transform.position.x);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (left && Time.time - time >= delaytime)
        {
            left = false;


            walljumpAvailable = false;

        }

    }
}
