using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnd = false;
    public float restartDelay = 2f;
    public GameObject winScreen;

    public void winLevel()
    {
        winScreen.SetActive(true);
    }

    public void endGame()
    {
        if (gameEnd == false)
        {
            gameEnd = true;
            Invoke("Restart", restartDelay); 
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
