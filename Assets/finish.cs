using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    public bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ColorManager.finished && collision.CompareTag("Player"))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(4, LoadSceneMode.Additive);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.V) )
            {

            Time.timeScale = 1.0f;
            SceneManager.LoadScene(4, LoadSceneMode.Additive);



        }

    }
}
