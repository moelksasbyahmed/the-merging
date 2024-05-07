using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static GameObject lastCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        if (lastCheckPoint == null )
        lastCheckPoint = GameObject.Find("Table1 (1)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float time;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && menu.enableSavingbool && collision.gameObject.name == "walls")
        {
            if(Time.time-time >= 1) {

            
            lastCheckPoint = this.gameObject;
            GameObject.Find("EventSystem").GetComponent<loadManager>().savee(gameObject.name);
            Debug.Log("ok it saved?");
            }
           
        }
    }
}
