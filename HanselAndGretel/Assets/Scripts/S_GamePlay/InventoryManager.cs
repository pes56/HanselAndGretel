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

                //instantiate the item from scriptable object data
                Vector3 spawnPosition = slotPos;
                GameObject currentItemPrefab = Instantiate(hotbarSlots[slotIndex].currentItem.itemPrefab, spawnPosition, Quaternion.identity);

                //put the instantiated item in the item slot
                Transform canvasTransform = FindObjectOfType<Canvas>().transform;
                currentItemPrefab.transform.SetParent(canvasTransform, false);
                currentItemPrefab.transform.position = slotPos;

                //check what scene is active
                Scene currentScene = SceneManager.GetActiveScene();
                hotbarSlots[slotIndex].currentItem.activeInScene = currentScene.name;
                Debug.Log(currentScene.name);


            }

            else
            {

            }
        }
    }

    public void Update()
    {
        hotbar = GameObject.FindGameObjectWithTag("Hotbar");
    }
}
