using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateItems : MonoBehaviour
{
    ItemManager itemManager;

    public void Awake()
    {
        
        itemManager = FindObjectOfType<ItemManager>();

        foreach (ItemScriptableObject item in itemManager.itemsInGame)
        {
            if (item.activeInScene != null)
            {

                if (item.activeInScene != SceneManager.GetActiveScene().name && item.inHotbar == false)
                {
                    GameObject itemToDelete = GameObject.FindGameObjectWithTag(item.name);
                    Destroy(itemToDelete);
                   
                }

                else if (item.activeInScene == SceneManager.GetActiveScene().name && item.inHotbar == false && item.untouched == false)
                {
                    
                    
                    //destroy items that shouldn't be there
                    GameObject itemToDelete = GameObject.FindGameObjectWithTag(item.name);
                    
                    Destroy(itemToDelete);

                    //instantiate item at last position

                    
                    GameObject itemPrefab = item.itemPrefab;
                    Vector3 spawnPosition = item.lastPosition;
                    
                    GameObject newItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
                    
                    Transform canvasTransform = FindObjectOfType<Canvas>().transform;
                    newItem.transform.SetParent(canvasTransform, true);
                    newItem.transform.localPosition = spawnPosition;
                    newItem.transform.localScale = item.itemScale;
                }
                
            }

        }
    }
}
