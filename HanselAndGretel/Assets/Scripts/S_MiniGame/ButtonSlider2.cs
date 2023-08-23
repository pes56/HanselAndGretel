using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider2 : MonoBehaviour
{
    public Slider slider;
    public Button increaseButton;
    public GameObject centerArea;

    public float increaseAmount = 10f;
    public float maxSliderValue = 100f;

    private void Start()
    {
        increaseButton.onClick.AddListener(IncreaseSliderValue);
    }

    private void IncreaseSliderValue()
    {
        slider.value += increaseAmount;

        if (slider.value >= maxSliderValue)
        {
            slider.value = maxSliderValue;
            slider.gameObject.SetActive(false);
            centerArea.SetActive(false);
        }

    }
}
