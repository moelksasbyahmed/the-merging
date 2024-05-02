using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
[Serializable]
public class loadManager : MonoBehaviour
{
    // public List<GameObject> interacableItems = new List<GameObject>();
    public GameObject parentInter;
    public GameObject empty;
    //public CheckPoint lastCheck;



    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            load();
        }
        if(Input.GetKeyUp(KeyCode.O))
        {
            saving.save(parentInter,empty);
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
        Player_Data obj = new Player_Data();
        obj = JsonUtility.FromJson<Player_Data>(File.ReadAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt")));
        Instantiate(obj.parent);
        Debug.Log(obj.childNumber);


    }

}

[Serializable]
class Player_Data
{
    public GameObject parent;
    public int childNumber;



    


}


