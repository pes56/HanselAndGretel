
using UnityEngine;

[CreateAssetMenu(fileName = "New Slot", menuName = "Inventory/Slot")]
public class SlotScriptableObject : ScriptableObject
{
    public int slot;
    public ItemScriptableObject currentItem;

    public void OnEnable()
    {
        currentItem = null;
    }
}
