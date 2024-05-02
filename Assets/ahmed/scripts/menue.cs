using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menue : MonoBehaviour
{

    public GameObject oa;
    public void start()
    {
        Time.timeScale = 1.0f;
        paused = false;
        oa.SetActive(false);

    }
    public void main()
    {
        start();
        SceneManager.LoadScene(0);

    }
    public void quit()
    {
        start();
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0.0f;
            oa.SetActive(true);
            paused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            start();
            

        }

        
    }
}
