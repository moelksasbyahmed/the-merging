using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            transform.parent.GetComponent<Controler>().isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            transform.parent.GetComponent<Controler>().isGrounded = false;
        }

    }

}
