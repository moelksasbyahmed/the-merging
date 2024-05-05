using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    [SerializeField] public static List<Color> CollectedColors = new List<Color>();
    [SerializeField] public static List<Color> newCollectedColors = new List<Color>();
   
    // Start is called before the first frame update
    void Start()
    {

    }
    public int collected;
    // Update is called once per frame
    void Update()
    {
        collected = CollectedColors.Count;




    }
    public static  void resetColors()
    {
        GameObject.Find("Global Light 2D").GetComponent<Light2D>().color = Color.black;
        Color[] x = new Color[CollectedColors.Count];
        CollectedColors.CopyTo(x);
        newCollectedColors = x.ToList();
        Debug.Log(CollectedColors.Count);
        Debug.Log(newCollectedColors.Count);
        CollectedColors.Clear();
        Debug.Log(CollectedColors.Count);
        foreach(Color color in newCollectedColors)
        {
            Debug.Log(color);
            newColor(color);

        }
        newCollectedColors.Clear();
    }
    public static bool finished = false;

    public finish end;
    public static    void newColor(Color color)
    {
        GameObject.Find("ColorZonee").GetComponent<colorUi>().add(color);
        Debug.Log("in the new Color function");
            CollectedColors.Add(color);
        if (CollectedColors.Count <= 6)
        {

            GameObject.Find("Global Light 2D").GetComponent<Light2D>().color = Color.Lerp(GameObject.Find("Global Light 2D").GetComponent<Light2D>().color, color, 0.5f);

            Debug.Log("changed light color to " + color);
            Debug.Log("changed light color to " + color);
        }
        else
        {
            finished = true;
            GameObject.Find("Global Light 2D").GetComponent<Light2D>().color = Color.white;
           
           
        }

    }

}
