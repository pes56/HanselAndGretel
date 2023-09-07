using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonRequirement2 : MonoBehaviour, IDropHandler
{
    public Image requiredItem; // Reference to the GameObject of the required item
    public string fightSceneName = "FreeHansel"; // Name of the "FreeHansel" scene
    public AudioClip successSound; // Add a reference to your success sound
    private AudioSource audioSource; // Reference to an AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on the same GameObject
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null && draggedObject.GetComponent<Image>().sprite == requiredItem.sprite)
        {
            LoadFightScene();

            // Play the success sound
            if (successSound != null && audioSource != null)
            {
                audioSource.clip = successSound;
                audioSource.Play();
            }
        }
    }

    private void LoadFightScene()
    {
        SceneManager.LoadScene(fightSceneName);
    }
}
