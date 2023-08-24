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


    public ItemScriptableObject GetItemByName(string itemName)
    {
        return itemsInGame.Find(item => item.itemName == itemName);
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
                    
                }
            }
        }
    }

  

 

   
}
