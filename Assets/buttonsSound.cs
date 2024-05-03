using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsSound : MonoBehaviour
{
    
    public void startButton()
    {
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().Play();
    }
    public void normalButton()
    {
        GetComponent<AudioSource>().Play();
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
