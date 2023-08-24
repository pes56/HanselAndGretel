//ITEM SCRIPTABLE OBJECT

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public GameObject itemPrefab;
    public bool inHotbar;
    public string activeInScene;
    public GameObject gameLoadPosition;
    public Vector3 lastPosition;
    public Vector3 itemScale;
    public bool untouched;
    

    public void OnEnable()
    {
        inHotbar = false;
        activeInScene = null;
       
        lastPosition = gameLoadPosition.transform.localPosition;

    }
}

