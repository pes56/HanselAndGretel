using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custome/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    [TextArea(3, 10)] public string description;
}
