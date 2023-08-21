using UnityEngine;
using UnityEngine.UI;

public class PanelButtonBehavior : MonoBehaviour
{
    private void Start()
    {
        // Add a listener to the Button's onClick event.
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Handle the button click here.
        Debug.Log("Panel clicked!");
    }
}
