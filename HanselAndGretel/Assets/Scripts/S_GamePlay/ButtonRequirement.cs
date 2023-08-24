using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRequirement : MonoBehaviour, IDropHandler
{
    public Image requiredItem;
    public Button targetButton;

    private bool isImageDraggedOn = false;

    private Color normalButtonColor;
    private Color opaqueButtonColor;

    private void Start()
    {
        normalButtonColor = targetButton.image.color;
        opaqueButtonColor = normalButtonColor;
        opaqueButtonColor.a = 1f; // Set alpha channel to 1 (fully opaque)
        SetButtonColor(opaqueButtonColor);
        targetButton.interactable = false; // Disable the button initially
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.GetComponent<Image>());


        // Check if the dragged object is the required image
        if (eventData.pointerDrag.GetComponent<Image>().sprite == requiredItem.sprite)
        {
            Debug.Log(eventData.pointerDrag.GetComponent<Image>());
            isImageDraggedOn = true;
            targetButton.interactable = true; // Enable the button's functionality
            SetButtonColor(opaqueButtonColor); // Set the button's color to fully opaque
            ClickButton(); // Automatically click the button
        }
    }

    private void SetButtonColor(Color color)
    {
        targetButton.image.color = color;
    }

    private void ClickButton()
    {
        targetButton.onClick.Invoke(); // Invoke the button's click event
    }
}
