//ITEM DISPLAY
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemDisplay : MonoBehaviour
{
    public ItemScriptableObject itemData;

    public Image itemSprite;
    public string itemName;
    public string itemDesc;
    public GameObject prefab;


    private void Awake()
    {
        //assign variables at runtime
        itemName = itemData.itemName;
        itemSprite = gameObject.GetComponent<Image>();
        itemSprite.sprite = itemData.itemSprite;
        itemDesc = itemData.itemDescription;

        prefab = itemData.itemPrefab;

        //check what scene is active
        Scene currentScene = SceneManager.GetActiveScene();
        itemData.activeInScene = currentScene.name;
        


    }
}
