using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    HanselItemDesc hanselItemDesc;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    public string itemDesc;

    private void Awake()
    {
        hanselItemDesc = FindObjectOfType<HanselItemDesc>();
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

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        if (!FindObjectOfType<HanselItemDesc>())
        {
            return;
        }
        else
        {
            hanselItemDesc.hideSpeechBubble();
        }
    }

    public void OnEndDrag(PointerEventData eventdata)
    {

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }


}