using UnityEngine;
using UnityEngine.UI;

public class ToggleImageOnClick : MonoBehaviour
{
    public Image imageToShow;

    public bool isImageVisible = false;

    private void Start()
    {
        if (imageToShow != null)
        {
            imageToShow.gameObject.SetActive(false);
        }
    }

    public void ToggleImage()
    {
        isImageVisible = !isImageVisible;

        if (imageToShow != null)
        {
            imageToShow.gameObject.SetActive(isImageVisible);
        }
    }
}
