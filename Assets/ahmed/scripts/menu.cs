using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    bool muted = false;
    public TextMeshProUGUI mutetext;
    public Button Continuebutton;


    public Toggle hardcore;
    public Toggle enableSaving;
    public static bool hardCoreBool;
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

    bool wanttoStart = false;
    bool wanttoquit = false;


    public static bool enableSavingbool;
    public void newGame()
    {
        try
        {

        wanttoStart = true;
        time = Time.time;



        pp obj = new pp();
        obj.newSave = true;
        obj.child = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        obj.position = new Vector3 { x = 1.3f, y = -0.51f, z = 0f };
        obj.hardCore = hardcore.isOn;
        obj.enableSaving = enableSaving.isOn;

        hardCoreBool = hardcore.isOn;
        enableSavingbool = enableSaving.isOn;

        obj.allTime = 0;
        saving.globalAllTime = 0;

        string json = JsonUtility.ToJson(obj);



        File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), json);

        }
        catch(Exception e) {
        
            File.AppendAllText(Path.Combine(Application.dataPath, "Resources/" + "log.txt"), $"{e.Message}       {e.StackTrace}     \nfileExist = false;\n");

        }

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
    bool fileExist = true;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            pp obj = new pp();
            obj = JsonUtility.FromJson<pp>(File.ReadAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt")));
            _ = obj.corpsPositions;
            _ = obj.position;
            _ = obj.deathNumber;
            _ = obj.checkName;
            _ = obj.child;
            _ = obj.numberOfCorpses;
            _ = obj.newSave;
            _ = obj.childNumber;
        }
        catch (Exception e)
        {
            fileExist = false;
            File.AppendAllText(Path.Combine(Application.dataPath, "Resources/" + "log.txt"), $"{e.Message}       {e.StackTrace}     \nfileExist = false;\n");
        }

        if (!fileExist)
        {
            Continuebutton.interactable = false;

        }


    }
    float time;
    // Update is called once per frame
    void Update()
    {
        try
        {

            if (wanttoStart)
            {
                if (Time.time - time >= 2.6f)
                {
                    SceneManager.LoadScene(1);
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);

                    SceneManager.sceneLoaded += onloaded;
                    wanttoStart = false;
                }
            }

            if (wanttoquit)
            {
                if (Time.time - time >= 2.6f)
                {
                    Application.Quit();


                }
            }



            if (SceneManager.loadedSceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(3);
            }

        }
        catch (Exception e)
        {
            File.AppendAllText(Path.Combine(Application.dataPath, "Resources/" + "log.txt"), $"{e.Message}      {e.StackTrace}");

        }
    }

    private void onloaded(Scene scene, LoadSceneMode loadmode)
    {
        try
        {

            Debug.Log(scene);
            if (scene.isLoaded && scene.buildIndex == 1)
            {
                Debug.Log("inside");
                Debug.Log(Controler.newSave);

                SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));

            }

        }
        catch (Exception e)
        {
            File.AppendAllText(Path.Combine(Application.dataPath, "Resources/" + "log.txt"), $"{e.Message}   {e.StackTrace}");

        }

    }

}
