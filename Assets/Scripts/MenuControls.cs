using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void BackPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
