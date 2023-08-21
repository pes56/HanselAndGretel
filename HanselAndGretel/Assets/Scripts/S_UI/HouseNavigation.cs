using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseNavigation : MonoBehaviour
{
    public void MainRoom()
    {
        SceneManager.LoadScene("HallWay");
    }

    public void BasementD()
    {
        SceneManager.LoadScene("Basement");
    }

    public void HallwayF()
    {
        SceneManager.LoadScene("Hansel Room");
    }

    public void HallwayR()
    {
        SceneManager.LoadScene("Kitchen");
    }
    public void HallwayL()
    {
        SceneManager.LoadScene("MainRoom");
    }
}