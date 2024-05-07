
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class won : MonoBehaviour
{
    public Text text;
    public Text timee;
    public Text achevs;
    public void main()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        achevs.text = $"enableSaving: {menu.enableSavingbool} \n hardCore: {menu.hardCoreBool}";
        timee.text = $"Time: {Time.timeSinceLevelLoad : 0.00}";
        text.text = $"{Controler.deathTimes}";
        
    }


    public bool wantToRestart = false;
    float time;

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
       

    }


    // Update is called once per frame
    void Update()
    {
        if (wantToRestart)
        {
            if (Time.time - time >= 0.8f)
            {

                SceneManager.LoadScene(1);
                SceneManager.LoadScene(3, LoadSceneMode.Additive);

                wantToRestart = false;

            }
        }

    }
}
