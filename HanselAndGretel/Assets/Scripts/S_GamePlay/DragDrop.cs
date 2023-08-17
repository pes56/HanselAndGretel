using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler{

    [SerializeField] private Canvas canvas;
    ItemSlot itemSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public string itemDesc;

    private void Awake()
    {
        itemSlot = FindObjectOfType<ItemSlot>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventdata)
    {
        
        rectTransform.anchoredPosition += eventdata.delta / canvas.scaleFactor;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        
        itemSlot.hideSpeechBubble();
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }


}
