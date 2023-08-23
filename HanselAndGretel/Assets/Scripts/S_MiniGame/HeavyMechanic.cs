using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyMechanic : MonoBehaviour
{
    public Slider slider;
    public Button increaseButton;
    public GameObject centerArea;
    public Button mainButton; // Reference to the main button you want to move
    public Button leftSliderButton; // Reference to the left slider button
    public GameObject hiddenImagePrefab; // Reference to the hidden image you want to reveal

    public float increaseAmount = 10f;
    public float maxSliderValue = 100f;
    public float moveDistance = 50f; // Distance to move the main button
    public float leftBoundary = -5f; // Minimum x position for the main button

    private bool isMaxValueReached = false;
    private bool shouldMoveMainButton = false;
    private bool isMovingMainButton = false;
    private Vector3 targetPosition;

    private void Start()
    {
        increaseButton.onClick.AddListener(IncreaseSliderValue);
        targetPosition = mainButton.transform.position;
        hiddenImagePrefab.SetActive(false);
    }

    private void Update()
    {
        if (isMovingMainButton)
        {
            // Calculate the new position of the main button
            Vector3 currentPosition = mainButton.transform.position;
            float newX = currentPosition.x - moveDistance * Time.deltaTime;

            // Check if the new position is within the boundary
            if (newX < leftBoundary)
            {
                newX = leftBoundary; // Clamp the position to the left boundary
            }

            // Update the position of the main button
            currentPosition.x = newX;
            mainButton.transform.position = currentPosition;

            // Check if the main button has returned to the target position
            if (Vector3.Distance(mainButton.transform.position, targetPosition) < 0.01f)
            {
                mainButton.transform.position = targetPosition; // Ensure exact position
                isMovingMainButton = false; // Reset the flag once returned

                // Reveal the hidden image
                //hiddenImagePrefab.SetActive(true);

                // Enable the left slider button when the slider value returns to 0
                if (slider.value == 0)
                {
                    leftSliderButton.interactable = true;
                }
            }
        }
    }

    private void IncreaseSliderValue()
    {
        slider.value += increaseAmount;

        // Check if the slider value has reached or exceeded the maximum value
        if (slider.value >= maxSliderValue)
        {
            slider.value = maxSliderValue;
            shouldMoveMainButton = true; // Set the flag to start moving the main button
            isMovingMainButton = true; // Set the flag to start the movement process
            targetPosition = mainButton.transform.position - Vector3.right * moveDistance; // Set the target position for movement

            // Disable the left slider button when the slider is at its maximum value
            leftSliderButton.interactable = false;
        }
    }

    // Method called when the return slider reaches max value
    public void OnReturnSliderMaxValueReached()
    {
        // Reappear the hidden elements
        ReappearElements();
    }

    // Method to make hidden elements reappear
    public void ReappearElements()
    {
        // Reset the slider state
        slider.value = 0;

        // Reset the increase button state
        increaseButton.gameObject.SetActive(true);

        // Reset the center area state
        centerArea.gameObject.SetActive(true);

        // Enable the hidden image (don't disable it)
        hiddenImagePrefab.SetActive(true);

        // Enable the left slider button when the slider value returns to 0
        leftSliderButton.interactable = true;
    }
}
