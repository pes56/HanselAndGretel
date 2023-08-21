using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRequirement : MonoBehaviour, IDropHandler
{
    public Image requiredImage;
    public Button targetButton;

    private bool isImageDraggedOn = false;

    private Color normalButtonColor;

    private void Start()
    {
        normalButtonColor = targetButton.image.color;
        SetButtonColorOpaque(); // Set the button's color to fully opaque initially
        targetButton.interactable = false; // Disable the button initially
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Check if the dragged object is the required image
        if (eventData.pointerDrag.GetComponent<Image>() == requiredImage)
        {
            isImageDraggedOn = true;
            targetButton.interactable = true; // Enable the button's functionality
            SetButtonColorOpaque(); // Set the button's color to fully opaque
            ClickButton(); // Automatically click the button
        }
    }

    private void SetButtonColorOpaque()
    {
        Color opaqueColor = normalButtonColor;
        opaqueColor.a = 1f; // Set alpha channel to 1 (fully opaque)
        targetButton.image.color = opaqueColor;
    }

    private void ClickButton()
    {
        targetButton.onClick.Invoke(); // Invoke the button's click event
    }
}
