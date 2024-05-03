using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorUi : MonoBehaviour
{

    public GameObject ColorOrbui;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void add(Color color)
    {
      GameObject x =  Instantiate(ColorOrbui, transform);
        x.GetComponent<Image>().color = color;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
