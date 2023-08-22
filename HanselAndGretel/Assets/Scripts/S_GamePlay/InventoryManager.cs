using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject hotbar;
    public List<SlotScriptableObject> hotbarSlots = new List<SlotScriptableObject>();

    
    public static InventoryManager Instance { get; private set; }

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
    public void InstantiatePersistentUI(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < hotbarSlots.Count)
        {


            if (hotbarSlots[slotIndex].currentItem != null)
            {

                Vector3 spawnPosition = transform.position;
                GameObject currentItemPrefab = Instantiate(hotbarSlots[slotIndex].currentItem.itemPrefab, spawnPosition, Quaternion.identity);
                Debug.Log("There is an item in slot " + slotIndex);
            }

            else
            {
                Debug.Log("There is NO item in slot " + slotIndex);
            }
        }
    }

    public void Update()
    {
        hotbar = GameObject.FindGameObjectWithTag("Hotbar");
    }
}
