using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
