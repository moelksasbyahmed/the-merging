using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menue : MonoBehaviour
{

    public GameObject oa;
    public GameObject notice;
    public void start()
    {
        Time.timeScale = 1.0f;
        paused = false;
        oa.SetActive(false);

    }
    public void ok()
    {
        Time.timeScale = 1.0f;
        paused = false;
        notice.SetActive(false);

    }
    public TextMeshProUGUI mutetext;
    bool wanttoMain = false;
    public void main()
    {
        wanttoMain = true;
        time = Time.time;
        start();



    }
    bool muted = false;
    public void muteMusic()
    {
        if(muted)
        {
            GameObject.Find("Player").GetComponent<AudioSource>().mute = false;
            mutetext.text = "mute music";
            muted = false;

        }
        else
        {
        GameObject.Find("Player").GetComponent<AudioSource>().mute = true;
            mutetext.text = "unmute music";
            muted = true;


        }

    }
    float time;
    bool wanttoquit = false;
    public void quit()
    {
        wanttoquit = true;
        time = Time.time;

    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        paused = true;
        notice.SetActive(true);


    }
    bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (wanttoMain)
        {
            if (Time.time - time >= 1f)
            {
                SceneManager.LoadScene(0);

            }
        }

        if (wanttoquit)
        {
            if (Time.time - time >= 1f)
            {

                start();
                Application.Quit();


            }
        }


        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
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
