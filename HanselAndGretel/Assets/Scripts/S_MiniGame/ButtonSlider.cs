using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider : MonoBehaviour
{
    public Slider slider;
    public Button increaseButton;
    public GameObject centerArea;

    public Animator buttonAnimator;
    private static readonly int ShakeTriggerHash = Animator.StringToHash("Shake");

    public float increaseAmount = 10f;
    public float maxSliderValue = 100f;

    public Image buttonImage;
    public Sprite newButtonSprite;

    public GameObject hiddenImage; // Reference to the hidden Image component

    private bool shouldPlayAnimation = false;

    private void Start()
    {
        increaseButton.onClick.AddListener(IncreaseSliderValue);
        shouldPlayAnimation = false;
    }

    private void Update()
    {
        if (shouldPlayAnimation)
        {
            buttonAnimator.SetTrigger(ShakeTriggerHash);
            shouldPlayAnimation = false;
        }
    }

    private void IncreaseSliderValue()
    {
        slider.value += increaseAmount;

        if (slider.value >= maxSliderValue)
        {
            slider.value = maxSliderValue;
            slider.gameObject.SetActive(false);
            centerArea.SetActive(false);
            StopAnimation();

            if (hiddenImage != null)
            {
                Image imageComponent = hiddenImage.gameObject.GetComponent<Image>();
                imageComponent.enabled = true; // Show the hidden image
            }
        }
        else
        {
            shouldPlayAnimation = true;
        }
    }

    private void StopAnimation()
    {
        buttonAnimator.speed = 0f;
        buttonAnimator.Play(buttonAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);

        if (buttonImage != null && newButtonSprite != null)
        {
            buttonImage.sprite = newButtonSprite;
        }

        if (hiddenImage != null)
        {

            Image imageComponent = hiddenImage.gameObject.GetComponent<Image>();

            imageComponent.enabled = true; // Show the hidden image
        }
    }
}
