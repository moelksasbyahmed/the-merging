
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class won : MonoBehaviour
{
    public Text text;
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
        text.text = $"{Controler.deathTimes}";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
