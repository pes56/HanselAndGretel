using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRequirement : MonoBehaviour, IDropHandler
{
    public Image requiredItem;
    public Button targetButton;
    public AudioClip keySound; // Add a reference to your key sound

    private bool isImageDraggedOn = false;

    private Color normalButtonColor;
    private Color opaqueButtonColor;
    private AudioSource audioSource; // Reference to an AudioSource component

    private void Start()
    {
        normalButtonColor = targetButton.image.color;
        opaqueButtonColor = normalButtonColor;
        opaqueButtonColor.a = 1f; // Set alpha channel to 1 (fully opaque)
        SetButtonColor(opaqueButtonColor);
        targetButton.interactable = false; // Disable the button initially

        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on the same GameObject
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Check if the dragged object is the required image
        if (eventData.pointerDrag.GetComponent<Image>().sprite == requiredItem.sprite)
        {
            isImageDraggedOn = true;
            targetButton.interactable = true; // Enable the button's functionality
            SetButtonColor(opaqueButtonColor); // Set the button's color to fully opaque
            ClickButton(); // Automatically click the button

            // Play the key sound
            if (keySound != null && audioSource != null)
            {
                audioSource.clip = keySound;
                audioSource.Play();
            }
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
