using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDescriptionHandler : MonoBehaviour, IPointerClickHandler
{
    public ItemDescriptionDisplay descriptionDisplay;
    public ItemData itemData;
    public DragDrop dragDrop; 

    public void OnPointerClick(PointerEventData eventData)
    {

        dragDrop = eventData.pointerClick.GetComponent<DragDrop>();
        if (eventData.button == PointerEventData.InputButton.Right && dragDrop.isItemInSlot == true)
        {
            descriptionDisplay.DisplayDescription(itemData.description);
        }

        else
        {
            descriptionDisplay.DisplayDescription("");
        }
    }
}
