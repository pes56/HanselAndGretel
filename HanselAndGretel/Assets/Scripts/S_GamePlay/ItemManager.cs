using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public List<ItemScriptableObject> itemsInGame = new List<ItemScriptableObject>();

    public static ItemManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecordItemPositions()
    {
        foreach (ItemScriptableObject item in itemsInGame)
        {
            if (item.activeInScene == SceneManager.GetActiveScene().name)
            {
                GameObject itemObject = GameObject.FindGameObjectWithTag(item.itemName);
                if (itemObject != null)
                {
                    item.lastPosition = itemObject.transform.localPosition;
                    Debug.Log("Recording " + item.itemName + "'s last position as " + item.lastPosition);
                }
            }
        }
    }

    public void SetItemPositions(string sceneName)
    {
        foreach (ItemScriptableObject item in itemsInGame)
        {
            if (item.activeInScene == sceneName)
            {
                Debug.Log(item.itemName + " is active in the current scene.");

                Debug.Log("Assigning " + item.itemName + " last known position");

                GameObject itemObject = GameObject.FindGameObjectWithTag(item.itemName);
                itemObject.transform.localPosition = item.lastPosition;

            }
        }
    }
}
