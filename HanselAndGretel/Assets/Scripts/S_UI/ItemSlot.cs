using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    DragDrop dragDrop;


    private bool hasItem;

   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {


            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
            dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
            hasItem = true;

        }
    }
}
