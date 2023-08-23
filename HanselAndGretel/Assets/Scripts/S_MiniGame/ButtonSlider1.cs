using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider1 : MonoBehaviour
{
    public Slider slider;
    public GameObject centerArea; // Reference to the GameObject containing the center area elements

    private bool isSpaceBarPressed = false;
    public float increaseAmount = 10f; // Amount to increase the slider value by
    public float maxSliderValue = 100f; // Maximum value for the slider

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpaceBarPressed = true;
            IncreaseSliderValue(); // Trigger the slider value increase
        }

        if (isSpaceBarPressed)
        {
            slider.value += increaseAmount * Time.deltaTime; // Increase over time

            // Check if the slider value has reached or exceeded the maximum value
            if (slider.value >= maxSliderValue)
            {
                slider.gameObject.SetActive(false); // Disable the slider GameObject
                centerArea.SetActive(false); // Disable the center area GameObject
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpaceBarPressed = false;
        }
    }

    private void IncreaseSliderValue()
    {
        slider.value += increaseAmount;

        // Check if the slider value has reached or exceeded the maximum value
        if (slider.value >= maxSliderValue)
        {
            slider.gameObject.SetActive(false); // Disable the slider GameObject
            centerArea.SetActive(false); // Disable the center area GameObject
        }
    }
}