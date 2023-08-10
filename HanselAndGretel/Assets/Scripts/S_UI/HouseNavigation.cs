using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseNavigation : MonoBehaviour
{
    public void MainRoom()
    {
        SceneManager.LoadScene("HallWay");
    }

    public void HallwayF()
    {
        SceneManager.LoadScene("Basement");
    }

    public void HallwayR()
    {
        SceneManager.LoadScene("HanselRoom");
    }

    public void HallwayL()
    {
        SceneManager.LoadScene("Kitchen");
    }

    public void Escape()
    {
        SceneManager.LoadScene("GoodEnding");
    }
}