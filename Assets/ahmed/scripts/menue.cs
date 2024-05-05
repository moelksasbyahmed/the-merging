using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        wantToRestart = true;
        time = Time.time;



        pp obj = new pp();
        obj.newSave = true;
        obj.child = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        obj.position = new Vector3 { x = 1.3f, y = -0.51f, z = 0f };

        string json = JsonUtility.ToJson(obj);



        File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), json);
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

        Debug.Log(Controler.newSave);
        if (Controler.newSave)
        {
            Time.timeScale = 0f;
            paused = true;

            notice.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;

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
                wanttoMain = false;
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

                SceneManager.LoadScene(1);
                SceneManager.LoadScene(3, LoadSceneMode.Additive);

                SceneManager.sceneLoaded += onloaded;
                wantToRestart = false;

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

  private void  onloaded(Scene scene,LoadSceneMode loadmode)
    {
        Debug.Log(scene);
        if (scene.isLoaded && scene.buildIndex == 1)
        {
            Debug.Log("loaded from menueeee (pause screen)");


          
        }


    }
}
