using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menue : MonoBehaviour
{
    loadManager lm;
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
        Controler.newSave = false;

    }
    public bool wantToRestart=false;
    public void restart()
    {
        Controler.newSave = true;
        lm.savee();
        wantToRestart = true;
        Time.timeScale = 1.0f;
        paused = false;

    }


    public void reloadLast()
    {
       
        wantToRestart = true;
        Time.timeScale = 1.0f;
        paused = false;

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
      
        start();
        wanttoquit = true;
        time = Time.time;

    }
    bool done = false;
    private void Awake()
    {
            notice.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {

        try
        {

        lm = GameObject.Find("EventSystem").GetComponent<loadManager>();
            done = true;
        }
        catch
        {
            done = false;
        }
        
        notice.SetActive(false);

        if (Controler.newSave)
        {
        Time.timeScale = 0f;
        paused = true;

            notice.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            paused = false
                ;
            notice.SetActive(false);
        }

    }
    bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if(!done)
        {
            try
            {

                lm = GameObject.Find("EventSystem").GetComponent<loadManager>();
                done = true;
            }
            catch
            {
                done = false;
            }

        }
        if (wanttoMain)
        {
            if (Time.time - time >= 1f)
            {
                SceneManager.LoadScene(0);

            }
        }

        if (wanttoquit)
        {
            if (Time.time - time >= 0.8f)
            {

                start();
                Application.Quit();


            }
        }

        if (wantToRestart)
        {
            if (Time.time - time >= 0.8f)
            {

                SceneManager.LoadSceneAsync(3);
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

                SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));


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
