using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionDisplay : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;

    public void DisplayDescription(string description)
    {
        descriptionText.text = description;
        
    }
}
