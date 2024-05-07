using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawtrigger : MonoBehaviour
{
    public GameObject saw;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !menu.hardCoreBool)
        {
            saw.GetComponent<BoxCollider2D>().enabled = true;
            saw.transform.position += new Vector3 { y = 0.5f };
            saw.GetComponent<saw>().started = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
           
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
