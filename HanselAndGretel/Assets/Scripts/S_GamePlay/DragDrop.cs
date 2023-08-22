using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler{

    HanselItemDesc hanselItemDesc;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    public InventoryManager inventoryManager;
    public bool holdingItem = false;

    

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
    }


    public void OnDrag(PointerEventData eventdata)
    {
        
        rectTransform.anchoredPosition += eventdata.delta / canvas.scaleFactor;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        holdingItem = true;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        //inventoryManager.UpdateItemInSlot()
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

    public void OnEndDrag(PointerEventData eventdata)
    {
        holdingItem = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }


}
