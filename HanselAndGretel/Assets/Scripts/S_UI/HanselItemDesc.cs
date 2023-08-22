using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HanselItemDesc : MonoBehaviour, IDropHandler
{
    
    ItemDisplay itemDisplay;
    public GameObject speechBubble;
    public TextMeshProUGUI hanselItemDesc;

    private bool hasItem;

    public void Awake()
    {
        speechBubble.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (!hasItem && eventData.pointerDrag != null)
        {


            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
            itemDisplay = eventData.pointerDrag.GetComponent<ItemDisplay>();
            hasItem = true;
            Vector3 yOffset = eventData.pointerDrag.GetComponent<RectTransform>().transform.position;
            yOffset.y -= 1f;
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = yOffset;

            if (hasItem == true)
                {
                    showSpeechBubble();
                }

            else
                {
                    hideSpeechBubble();
                }

            


        }
    }
    public void hideSpeechBubble()
    {
        speechBubble.SetActive(false);
        hasItem = false;
    }
    public void showSpeechBubble()
    {
        speechBubble.SetActive(true);
        hanselItemDesc.text = itemDisplay.itemDesc;
    }
}
