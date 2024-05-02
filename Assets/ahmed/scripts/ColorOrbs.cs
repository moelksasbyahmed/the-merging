using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorOrbs : MonoBehaviour
{

    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        transform.GetComponent<Light2D>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player")) 
        {
            ColorManager.newColor(color);
            Destroy(gameObject);
            
        }
    }
}
