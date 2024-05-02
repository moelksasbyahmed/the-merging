using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool left = false;
    float time;
   public float delaytime = 0.5f;
    // Update is called once per frame
    void Update()
    { 
        if( left&&Time.time - time >= delaytime)
        {
            left = false;

            transform.parent.GetComponent<Controler>().isGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            left = false;   
            transform.parent.GetComponent<Controler>().isGrounded = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            time = Time.time;
            left = true;
        }

    }

}
