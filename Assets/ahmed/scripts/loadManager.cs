using System;
using System.IO;
using UnityEngine;
[Serializable]
public class loadManager : MonoBehaviour
{
    // public List<GameObject> interacableItems = new List<GameObject>();



    public GameObject colorOrbs_prefab;
    //  public  GameObject colorOrbs;
    public GameObject player;
    //public CheckPoint lastCheck;

    private void Start()
    {
        try
        {
            load();
            if (!Controler.newSave)
            {

                saving.realLoad(GameObject.Find("color orbs"), colorOrbs_prefab, player);
            }
        }
        catch (Exception e)
        {
            Debug.Log("file error");
            Controler.newSave = true;

        }
    }
    public void loade()
    {
        saving.realLoad(GameObject.Find("color orbs"), colorOrbs_prefab, player);



    }
    public void savee()
    {
        saving.realSave(GameObject.Find("color orbs"), player);

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            load();
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            saving.realSave(GameObject.Find("color orbs"), player);
            // saving.save();
        }
    }

    public void save()
    {


        //  Debug.Log("saving started");


        //  Player_Data obj = new Player_Data();
        //  obj.parent = parentInter;
        //  obj.childNumber = parentInter.transform.childCount;
        //  // obj.parentInter = _parentInter;

        //string json =  JsonUtility.ToJson(obj);



        //  File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), json);

        //  // Close the file to prevent any corruptions


        //  Debug.Log("Serialized Result: true");
    }
    public static void load()
    {
        pp obj = new pp();
        obj = JsonUtility.FromJson<pp>(File.ReadAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt")));
        Controler.newSave = obj.newSave;
        Debug.Log(obj.newSave);


    }

}

[Serializable]
class Player_Data
{
    public GameObject parent;
    public int childNumber;






}


