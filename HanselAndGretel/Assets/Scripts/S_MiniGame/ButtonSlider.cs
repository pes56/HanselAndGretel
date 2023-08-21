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

    public Image buttonImage; // Reference to the Image component of the button
    public Sprite newButtonSprite; // The new sprite to be applied when the animation stops

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

        // Change the sprite of the button's Image component
        if (buttonImage != null && newButtonSprite != null)
        {
            buttonImage.sprite = newButtonSprite;
        }
    }
}
