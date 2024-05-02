using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class saving : ScriptableObject
{
    //public string componentTypeName; // Name of the component to get (e.g., "MyComponent")

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
    public static void save(GameObject gameobject, GameObject empty)
    {
       GameObject nw = Instantiate(empty);
        Component[] components = gameobject.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
            if (nw.GetComponent(component.GetType()) == null)
            {
            Component newComponent =     nw.AddComponent(component.GetType());
                dynamic x = gameobject.GetComponent(component.GetType());
                Debug.Log( x.isTrigger);
                //this is working u can get the properities by its names from the original component then save it, then load it again and do the reverse to aplply the properities and u can use (dynamic properity fitcher ) o get all the properities
            }
            else
            {
                Debug.Log("f;u");
            }
            
        }

    }
}

struct instance
{
    public string name;
    public List<dynamic> Components;
    public List<instance> childs;
}
