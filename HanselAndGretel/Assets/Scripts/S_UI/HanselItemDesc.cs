using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HanselItemDesc : MonoBehaviour, IDropHandler
{
    DragDrop dragDrop;
    ItemDisplay itemDisplay;
    public GameObject speechBubble;
    public TextMeshProUGUI hanselItemDesc;
    public TextMeshProUGUI hanselItemText; // Reference to the TextMeshProUGUI component

    private bool hasItem;

    public void Awake()
    {
        speechBubble.SetActive(false);
        hanselItemText.gameObject.SetActive(false); // Hide the TextMeshProUGUI component initially
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!hasItem && eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
            dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
            itemDisplay = eventData.pointerDrag.GetComponent<ItemDisplay>();
            hasItem = true;
            Vector3 yOffset = eventData.pointerDrag.GetComponent<RectTransform>().transform.position;
            yOffset.y -= 1f;
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = yOffset;

            if (hasItem)
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
        hanselItemText.gameObject.SetActive(false); // Hide speech bubble
        hasItem = false;
    }

    public void showSpeechBubble()
    {
        speechBubble.SetActive(true);
        hanselItemDesc.text = itemDisplay.itemDesc;
        hanselItemText.gameObject.SetActive(true); // Show tspeech bubble
    }
}
