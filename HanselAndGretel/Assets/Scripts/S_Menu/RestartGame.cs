using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        // Load the "Fight" scene by name
        SceneManager.LoadScene("Fight");
    }
}
