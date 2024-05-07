using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disabledForSaving : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() 
    {
        GetComponent<Button>().interactable = menu.enableSavingbool;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
