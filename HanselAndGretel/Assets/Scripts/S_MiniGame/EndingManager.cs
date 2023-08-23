using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public Slider slider1; // Reference to the first slider
    public Slider slider2; // Reference to the second slider
    public Slider slider3; // Reference to the third slider
    public Slider slider4; // Reference to the fourth slider

    private bool slider1Maxed = false;
    private bool slider2Maxed = false;
    private bool slider3Maxed = false;
    private bool slider4Maxed = false;

    private void Start()
    {
        // Disable sliders 3 and 4 initially
        slider3.interactable = false;
        slider4.interactable = false;
    }

    private void Update()
    {
        if (!slider1Maxed && slider1.value >= slider1.maxValue)
        {
            slider1Maxed = true;
            slider3.interactable = true; // Enable slider3
        }

        if (!slider2Maxed && slider2.value >= slider2.maxValue)
        {
            slider2Maxed = true;
            slider4.interactable = true; // Enable slider4
        }

        if (slider1Maxed && slider2Maxed)
        {
            if (!slider3Maxed && slider3.value >= slider3.maxValue)
            {
                slider3Maxed = true;
            }

            if (!slider4Maxed && slider4.value >= slider4.maxValue)
            {
                slider4Maxed = true;
            }

            if (slider3Maxed && slider4Maxed)
            {
                SceneManager.LoadScene("GoodEnding");
            }
        }
    }
}
