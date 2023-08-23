//ITEM SCRIPTABLE OBJECT

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public GameObject itemPrefab;
    public bool InHotbar;
}
