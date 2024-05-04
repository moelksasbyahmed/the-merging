using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saving : ScriptableObject
{
    public string componentTypeName; // Name of the component to get (e.g., "MyComponent")

    //public void GetComponentByType()
    //{

    //    // Get the type of the component based on the name
    //    Type componentType = Type.GetType(componentTypeName);

    //    // Check if the type exists and is a component
    //    if (componentType != null && componentType.IsSubclassOf(typeof(Component)))
    //    {
    //        // Get the component using reflection
    //        Component component = GetComponent(componentType);

    //    }
    //}

  

    public static void InspectComponent(Component component)
    {
        
        Type componentType = component.GetType();
        
        FieldInfo[] fields = componentType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Debug.Log( componentType.GetMember("isTrigger")[0]);
        
        Debug.Log("im ghere");
        foreach (FieldInfo field in fields)
        {
            Debug.Log($"Property Name: {field.Name}, Value: {field.GetValue(component)}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameobject"> the source of the save</param>
    /// <param name="empty"> the target wich will be opied to</param>
    /// 

    
   static int   numberOfChilds;
    static List<int> childs = new List<int>();
    public static  void realSave(GameObject colorOrbs,GameObject player)
    {
        childs.Clear();
        numberOfChilds = colorOrbs.transform.childCount;
        for(int i = 0; i < numberOfChilds; i++)
        {
         childs.Add(   int.Parse(colorOrbs.transform.GetChild(i).name));
        }
        pp obj = new pp();
        obj.childNumber = numberOfChilds;
        obj.child = childs;
        obj.position = player.transform.position + new Vector3 { x = 2f};
        obj.deathNumber = Controler.deathTimes;
        obj.newSave = Controler.newSave;
        string json =  JsonUtility.ToJson(obj);



         File.WriteAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt"), json);


    }
     
    
   public static void realLoad(GameObject colorOrbs,GameObject colorOrbs_prefab, GameObject player)
    {
        pp obj = new pp();
        obj = JsonUtility.FromJson<pp>(File.ReadAllText(Path.Combine(Application.dataPath, "Resources/" + "saves.txt")));
        player.transform.position = obj.position;
        Controler.deathTimes = obj.deathNumber;
        Controler.newSave = obj.newSave;
        Destroy(GameObject.Find("color orbs").gameObject);
      GameObject x =  Instantiate(colorOrbs_prefab);
        x.name = "color orbs";
        ColorManager.CollectedColors.Clear();
        ColorManager.newCollectedColors.Clear();
        ColorManager.light.color = Color.black;//some bug in this area
        for (int i = 0;i <7;i++)
        {
            if(!obj.child.Exists(item => item == i))
            {
                ColorManager.newColor(x.transform.GetChild(7-i-1).GetComponent<SpriteRenderer>().color);
                Destroy(x.transform.GetChild(7 - i -1).gameObject);

            }

        }
        Debug.Log(obj.childNumber);
    }
    public static void save(GameObject gameobject, GameObject empty)
            {
                GameObject nw = Instantiate(empty);
                Component[] components = gameobject.GetComponents(typeof(Component));
                foreach (Component component in components)
                {
                    Debug.Log(component.ToString());
                    if (nw.GetComponent(component.GetType()) == null)
                    {
                        Component newComponent = nw.AddComponent(component.GetType());
                        dynamic x = gameobject.GetComponent(component.GetType());
                InspectComponent(x);
                       // Debug.Log(x.isTrigger);
                        //this is working u can get the properities by its names from the original component then save it, then load it again and do the reverse to aplply the properities and u can use (dynamic properity fitcher ) o get all the properities
                    }
                    else
                    {

                        Debug.Log("f;u");
                    }

                }

            }
        }
[Serializable]
class pp
{
    public Vector3 position;
    public int childNumber;
    public int deathNumber;
    public bool newSave;
   public List<int> child;





}
