using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJump : MonoBehaviour
{
    public float direction;
   public bool walljumpAvailable; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
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
          direction =  Mathf.Sign( collision.transform.position.x - transform.position.x);
            walljumpAvailable = false;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
