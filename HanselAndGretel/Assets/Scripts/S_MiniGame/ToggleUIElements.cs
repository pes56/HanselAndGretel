using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUIElements : MonoBehaviour
{
    [System.Serializable]
    public class UISet
    {
        public Slider slider;
        public Button increaseButton;
        public GameObject centerArea;
    }

    public List<UISet> uiSets = new List<UISet>();
    private bool elementsVisible = false;

    private void Start()
    {
        HideUIElements();
    }

    public void ToggleVisibility()
    {
        elementsVisible = !elementsVisible;

        if (elementsVisible)
        {
            ShowUIElements();
        }
        else
        {
            HideUIElements();
        }
    }

    private void ShowUIElements()
    {
        foreach (var uiSet in uiSets)
        {
            uiSet.slider.gameObject.SetActive(true);
            uiSet.increaseButton.gameObject.SetActive(true);
            uiSet.centerArea.SetActive(true);
        }
    }

    private void HideUIElements()
    {
        foreach (var uiSet in uiSets)
        {
            uiSet.slider.gameObject.SetActive(false);
            uiSet.increaseButton.gameObject.SetActive(false);
            uiSet.centerArea.SetActive(false);
        }
    }
}
