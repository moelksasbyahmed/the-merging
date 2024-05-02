using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
   
    public void start()
    {
        SceneManager.LoadSceneAsync(3);
  
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
    }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.loadedSceneCount >1)
        {
            SceneManager.UnloadSceneAsync(3);
        }
        
    }
}
