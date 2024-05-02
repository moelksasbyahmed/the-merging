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
     public new   static Light2D  light;
    // Start is called before the first frame update
    void Start()
    {
        light = GameObject.Find("Global Light 2D").GetComponent<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {





    }
    public static  void resetColors()
    {
        light.color = Color.black;
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


    public static    void newColor(Color color)
    {
        if (CollectedColors.Count <= 6)
        {

            CollectedColors.Add(color);
            light.color = Color.Lerp(light.color, color, 0.5f);
        }
        else
        {
            light.color = Color.white;
            SceneManager.LoadScene(4,LoadSceneMode.Additive);
            GameObject.Find("Player").GetComponent<Controler>().alive = false;
        }

    }

}
