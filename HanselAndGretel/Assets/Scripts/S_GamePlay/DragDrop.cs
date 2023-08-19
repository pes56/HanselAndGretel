using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler{

    [SerializeField] private Canvas canvas;
    HanselItemDesc hanselItemDesc;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public string itemDesc;

    private void Awake()
    {
        hanselItemDesc = FindObjectOfType<HanselItemDesc>();
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

        hanselItemDesc.hideSpeechBubble();
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }


}
