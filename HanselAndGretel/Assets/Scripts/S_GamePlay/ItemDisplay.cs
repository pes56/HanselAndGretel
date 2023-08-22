using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemScriptableObject itemData;

    public Image itemSprite;
    public string itemName;
    public string itemDesc;
    public GameObject prefab;
    

    private void Awake()
    {
        
        itemName = itemData.itemName;
        itemSprite.sprite = itemData.itemSprite;
        itemDesc = itemData.itemDescription;

        prefab = itemData.itemPrefab;
        
        

    }
}
