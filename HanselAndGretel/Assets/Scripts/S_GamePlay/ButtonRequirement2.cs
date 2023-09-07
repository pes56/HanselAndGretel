using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonRequirement2 : MonoBehaviour, IDropHandler
{
    public Image requiredItem; // Reference to the GameObject of the required item
    public string fightSceneName = "FreeHansel"; // Name of the "FreeHansel" scene

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null && draggedObject.GetComponent<Image>().sprite == requiredItem.sprite)
        {
            LoadFightScene();
        }
    }

    private void LoadFightScene()
    {
        SceneManager.LoadScene(fightSceneName);
    }
}
