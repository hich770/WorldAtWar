 using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public void LoadScene(int sceneid)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneid);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    
}
