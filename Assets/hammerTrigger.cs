using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerTrigger : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!menu.hardCoreBool && collision.CompareTag("Player"))
        {

        animator.enabled = true;
        }
    }
}
