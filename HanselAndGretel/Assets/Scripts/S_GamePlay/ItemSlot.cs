//ITEM SLOT
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerExitHandler
{

    public SlotScriptableObject slotData;
    public InventoryManager inventoryManager;
    public ItemManager itemManager;

    public void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        itemManager = FindObjectOfType<ItemManager>();

        string sceneName = SceneManager.GetActiveScene().name;

        itemManager.DestroyOriginalObjects(sceneName);
        itemManager.SetItemPositions(sceneName);
        inventoryManager.InstantiatePersistentUI(slotData.slot, gameObject.transform.position);

    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;

            ItemDisplay itemDisplay = eventData.pointerDrag.GetComponent<ItemDisplay>();
            if (itemDisplay != null)
            {
                ItemScriptableObject droppedItemData = itemDisplay.itemData;

                if (droppedItemData != null)
                {
                    inventoryManager.AddItemToSlot(slotData.slot, droppedItemData);
                    droppedItemData.inHotbar = true;
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragDrop dragdrop = eventData.pointerDrag.GetComponent<DragDrop>();

            if (dragdrop.holdingItem == true)
            {
                inventoryManager.RemoveItemFromSlot(slotData.slot);
                dragdrop.holdingItem = false;

                ItemDisplay itemDisplay = eventData.pointerDrag.GetComponent<ItemDisplay>();
                if (itemDisplay != null)
                {
                    ItemScriptableObject droppedItemData = itemDisplay.itemData;
                    droppedItemData.inHotbar = false;
                }
            }


        }
    }
}
