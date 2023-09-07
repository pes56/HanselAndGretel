using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    HanselItemDesc hanselItemDesc;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    public InventoryManager inventoryManager;
    public bool holdingItem = false;
    ItemDisplay itemDisplay;
    private AudioSource audioSource; // Add this line to reference the AudioSource component

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
        audioSource = GetComponent<AudioSource>(); // Assign the AudioSource component in the Inspector
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        holdingItem = true;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        itemDisplay = GetComponent<ItemDisplay>();
        itemDisplay.itemData.untouched = false;

        if (!FindObjectOfType<HanselItemDesc>())
        {
            return;
        }
        else
        {
            hanselItemDesc = FindObjectOfType<HanselItemDesc>();
            hanselItemDesc.hideSpeechBubble();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        holdingItem = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Check if the object was dropped into the hotbar (you need to define your hotbar logic here)
        // For example, if your hotbar is a separate GameObject with a script that handles item drops, you can call a method like "ItemDroppedIntoHotbar" on that script here.

        // Play audio when the object is dropped
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Play audio when the object is clicked
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
