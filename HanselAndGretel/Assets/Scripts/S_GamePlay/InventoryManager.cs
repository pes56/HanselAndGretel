//INVENTORY MANAGER
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public GameObject hotbar;
    public List<SlotScriptableObject> hotbarSlots = new List<SlotScriptableObject>();


    public static InventoryManager Instance { get; private set; }

    //singleton pattern
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

    // Add an item to a specific hotbar slot
    public void AddItemToSlot(int slotIndex, ItemScriptableObject newItem)
    {
        if (slotIndex >= 0 && slotIndex < hotbarSlots.Count)
        {
            hotbarSlots[slotIndex].currentItem = newItem;
        }
    }

    // Remove an item from a specific hotbar slot
    public void RemoveItemFromSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < hotbarSlots.Count)
        {
            hotbarSlots[slotIndex].currentItem = null;
        }
    }

    //refresh hotbar on scene load
    public void InstantiatePersistentUI(int slotIndex, Vector3 slotPos)
    {
        if (slotIndex >= 0 && slotIndex < hotbarSlots.Count)
        {

            if (hotbarSlots[slotIndex].currentItem != null)
            {

                //check that there isnt already an item of this type in this scene
                if (GameObject.FindGameObjectWithTag(hotbarSlots[slotIndex].currentItem.name) != null)
                {
                    //delete items that already exsist
                    GameObject itemToDelete = GameObject.FindGameObjectWithTag(hotbarSlots[slotIndex].currentItem.name);
                    
                    Destroy(itemToDelete);
                    Debug.Log("Deleting Item");
                }
                
                Scene currentScene = SceneManager.GetActiveScene();
                Debug.Log(currentScene.name);
            
                if (hotbarSlots[slotIndex].currentItem.activeInScene != currentScene.name && hotbarSlots[slotIndex].currentItem.inHotbar == true)
                    {
                        //instantiate the item from scriptable object data
                        Vector3 spawnPosition = slotPos;
                        GameObject currentItemPrefab = Instantiate(hotbarSlots[slotIndex].currentItem.itemPrefab, spawnPosition, Quaternion.identity);
                        Debug.Log("instantiating at slot");

                        //put the instantiated item in the item slot
                        Transform canvasTransform = FindObjectOfType<Canvas>().transform;
                        currentItemPrefab.transform.SetParent(canvasTransform, false);
                        currentItemPrefab.transform.position = slotPos;

                        
                    }

               

                    //set this to active scene
                    hotbarSlots[slotIndex].currentItem.activeInScene = currentScene.name;
                    Debug.Log(currentScene.name);




            }

            
        }
    }

    public void Update()
    {
        hotbar = GameObject.FindGameObjectWithTag("Hotbar");
    }
}
