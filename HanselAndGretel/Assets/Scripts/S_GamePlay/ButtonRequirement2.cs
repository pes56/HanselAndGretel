using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonRequirement2 : MonoBehaviour, IDropHandler
{
    public GameObject requiredItem; // Reference to the GameObject of the required item
    public string fightSceneName = "Fight"; // Name of the "Fight" scene

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null && draggedObject == requiredItem)
        {
            LoadFightScene();
        }
    }

    private void LoadFightScene()
    {
        SceneManager.LoadScene(fightSceneName);
    }
}
