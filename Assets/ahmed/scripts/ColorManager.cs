using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorManager : MonoBehaviour
{
    [SerializeField] List<Color> CollectedColors;
    public Light2D light;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {





    }


    public    void newColor(Color color)
    {
        if (CollectedColors.Count <= 6)
        {

            CollectedColors.Add(color);
            light.color = Color.Lerp(light.color, color, 0.5f);
        }
        else
        {
            light.color = Color.white;
        }

    }

}
