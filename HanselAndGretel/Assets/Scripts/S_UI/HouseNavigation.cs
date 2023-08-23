using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseNavigation : MonoBehaviour
{
    public void HallWay()
    {
        SceneManager.LoadScene("HallWay");
    }

    public void BasementD()
    {
        SceneManager.LoadScene("Basement");
    }

    public void HanselRoom()
    {
        SceneManager.LoadScene("Hansel Room");
    }

    public void Kitchen()
    {
        SceneManager.LoadScene("Kitchen");
    }
    public void MainRoom()
    {
        SceneManager.LoadScene("MainRoom");
    }

    public void Shelf()
    {
        SceneManager.LoadScene("Shelf(CloseUp)");
    }
}