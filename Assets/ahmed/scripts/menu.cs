using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    bool muted = false;
    public TextMeshProUGUI mutetext;

    public void muteMusic()
    {
        if (muted)
        {
            GetComponent<AudioSource>().mute = false;
            mutetext.text = "mute music";
            muted = false;

        }
        else
        {
            GetComponent<AudioSource>().mute = true;
            mutetext.text = "unmute music";
            muted = true;


        }

    }

    bool wanttoStart= false;
    bool wanttoquit = false;
    public void newGame()
    {
        wanttoStart = true;
        time = Time.time;



        pp obj = new pp();
        obj.newSave = true;

        string json = JsonUtility.ToJson(obj);



        File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), json);


    }

    public void start()
    {
        wanttoStart = true;
        time = Time.time;

       
    }
    public void main()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        wanttoquit = true;
        time = Time.time;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float time;
    // Update is called once per frame
    void Update()
    {
        if(wanttoStart)
        {
            if(Time.time - time >= 2.6f)
            {
                SceneManager.LoadSceneAsync(3);
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

                SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));

            }
        }

        if (wanttoquit)
        {
            if (Time.time - time >= 2.6f)
            {
                Application.Quit();


            }
        }
      


        if (SceneManager.loadedSceneCount >1)
        {
            SceneManager.UnloadSceneAsync(3);
        }
        
    }
}
