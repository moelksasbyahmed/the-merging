using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    public bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ColorManager.finished && collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(4, LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
