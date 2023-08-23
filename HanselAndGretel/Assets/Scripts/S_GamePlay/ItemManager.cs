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

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        RecordItemPositions();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckActiveItemsInScene(scene.name);
    }

    private void RecordItemPositions()
    {
        foreach (ItemScriptableObject item in itemsInGame)
        {
            if (item.activeInScene == SceneManager.GetActiveScene().name && item.inHotbar == false)
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

    private void CheckActiveItemsInScene(string sceneName)
    {
        foreach (ItemScriptableObject item in itemsInGame)
        {
            if (item.activeInScene == sceneName)
            {
                Debug.Log(item.itemName + " is active in the current scene.");
            }
        }
    }
}
