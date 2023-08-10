using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    public void Prologue2()
    {
        SceneManager.LoadScene("Prologue2");
    }

    public void Prologue3()
    {
        SceneManager.LoadScene("Prologue3");
    }

    public void Prologue4()
    {
        SceneManager.LoadScene("Prologue4");
    }

    public void Prologue5()
    {
        SceneManager.LoadScene("Prologue5");
    }

    public void Prologue0()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("MainRoom2");
    }




}
