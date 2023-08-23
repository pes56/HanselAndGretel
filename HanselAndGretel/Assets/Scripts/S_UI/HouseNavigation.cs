using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseNavigation : MonoBehaviour
{
    public ItemManager itemManager;

    public void Awake()
    { 
        itemManager = FindObjectOfType<ItemManager>();
    }
    public void HallWay()
    {
        itemManager.RecordItemPositions();
        SceneManager.LoadScene("HallWay");
    }

    public void BasementD()
    {
        itemManager.RecordItemPositions();
        SceneManager.LoadScene("Basement");
    }

    public void HanselRoom()
    {
        itemManager.RecordItemPositions();
        SceneManager.LoadScene("Hansel Room");
    }

    public void Kitchen()
    {
        itemManager.RecordItemPositions();
        SceneManager.LoadScene("Kitchen");
    }
    public void MainRoom()
    {
        itemManager.RecordItemPositions();
        SceneManager.LoadScene("MainRoom");
    }

    public void Shelf()
    {
        itemManager.RecordItemPositions();
        SceneManager.LoadScene("Shelf(CloseUp)");
    }
}