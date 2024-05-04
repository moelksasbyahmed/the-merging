using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed;
    public float range;
    [Tooltip("if horizontal is true then the ground will be horizontally if not then it will move vertically")]
    public bool horizontal;
    Vector3 position;
    public float waitingTime;
    float time;
     Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
   
    private void Update()
    {
        if (Mathf.Abs(Vector3.Magnitude(transform.position - position)) >= range)
        {
            animator.enabled = false;
            //transform.localScale =new Vector3 { x = - transform.localScale.x, y = 1f, z = 1f };
            speed = -speed;
            position = transform.position;
            time = Time.time;

        }
    }
    public bool started = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if ( started&& Time.time - time >= waitingTime)
        {
            animator.enabled = true;



            if (horizontal)
            {
                transform.position += new Vector3 { x = speed * Time.deltaTime };
            }
            else
            {
                transform.position += new Vector3 { y = speed * Time.deltaTime };

            }
        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent.GetComponent<Controler>().damaged();
            
        }

    }

  
}
