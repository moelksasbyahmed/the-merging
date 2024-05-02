using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
          //  Debug.Log(collision.gameObject.name);
            collision.transform.GetComponent<Controler>().damaged();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
