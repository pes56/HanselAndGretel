using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnSlider : MonoBehaviour
{
    public Slider slider;
    public Button returnButton;
    public Button mainButton; // Reference to the main button you want to return
    public HeavyMechanic heavyMechanic; // Reference to the HeavyMechanic script

    public float increaseAmount = 10f;
    public float maxSliderValue = 100f;
    public float decreaseAmount = 10f;
    public float minSliderValue = 1f;

    public float returnSpeed = 10f; // Speed to move the object back

    private bool isMaxValueReached = false;
    private bool shouldReturnMainButton = false;
    private bool isReturningMainButton = false;
    private bool isMovingToOriginalPosition = false;

    private Vector3 originalPosition;

    private void Start()
    {
        returnButton.onClick.AddListener(ReturnObject);
        originalPosition = mainButton.transform.position;
    }

    private void Update()
    {
        if (isReturningMainButton)
        {
            // Move the main button back to its original position
            mainButton.transform.position = Vector3.MoveTowards(mainButton.transform.position, originalPosition, returnSpeed * Time.deltaTime);

            // Check if the main button has returned to its original position
            if (Vector3.Distance(mainButton.transform.position, originalPosition) < 0.01f)
            {
                isReturningMainButton = false; // Reset the flag once returned
                isMovingToOriginalPosition = false; // Reset the flag for moving to the original position

                // Reset the sliders and related flags in the ReturnSlider script
                ResetSlider(); // Reset the ReturnSlider sliders
            }
        }
    }

    private void ReturnObject()
    {
        // Increase the slider value
        slider.value += increaseAmount;

        // Check if the slider value has reached or exceeded the maximum value
        if (slider.value >= maxSliderValue)
        {
            slider.value = maxSliderValue;
            isMaxValueReached = true; // Set the flag to indicate max value reached
            shouldReturnMainButton = true; // Set the flag to start returning the main button
            isReturningMainButton = true; // Set the flag to start the return process
            isMovingToOriginalPosition = true; // Set the flag for moving to the original position
            OnReturnSliderMaxValueReached(); // Call the method to trigger HeavyMechanic's reappear logic
        }

        // Check if the slider value has reached or exceeded the minimum value
        if (slider.value <= minSliderValue)
        {
            slider.value = minSliderValue;
            isMaxValueReached = false; // Reset the flag if slider value is below minimum
        }
    }

    // Reset the slider state
    private void ResetSlider()
    {
        slider.value = minSliderValue;
        isMaxValueReached = false;
        shouldReturnMainButton = false;
    }

    // Method to notify HeavyMechanic when return slider reaches max value
    private void OnReturnSliderMaxValueReached()
    {
        heavyMechanic.OnReturnSliderMaxValueReached();
    }
}
