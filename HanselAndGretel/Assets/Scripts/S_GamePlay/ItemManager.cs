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
            if (item.activeInScene != null)
            {
                if (item.activeInScene == sceneName)
                {
                    GameObject itemPrefab = item.itemPrefab;
                    Vector3 spawnPosition = item.lastPosition;
                    GameObject newItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

                    GameObject itemObject = GameObject.FindGameObjectWithTag(item.itemName);
                    itemObject.transform.localPosition = item.lastPosition;

                }
            }
        }
    }

    public void DestroyOriginalObjects(string sceneName)
    {

        foreach (ItemScriptableObject item in itemsInGame)
        {
            if (item.activeInScene != null)
            {
                if (item.activeInScene == sceneName && item.inHotbar == true)
                {

                    Debug.Log(item.name + " is in a hotbar");
                    return;


                }
                else if (item.activeInScene == sceneName && item.unTouched)
                {
                    Debug.Log(item.name + " is untouched");
                    return;
                }
                else if (item.activeInScene == sceneName && item.unTouched == false && item.lastPosition != item.gameLoadPosition.transform.position && item.inHotbar == false)
                {
                    Debug.Log("Destroying");
                    Destroy(GameObject.FindGameObjectWithTag(item.itemName));
                }
            }
        }
    }

   
}
