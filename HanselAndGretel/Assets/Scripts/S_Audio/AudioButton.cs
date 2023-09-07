using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public AudioSource audioSource; // Drag and drop your AudioSource here in the Inspector
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        // Add a listener to the button's click event
        button.onClick.AddListener(PlayAudio);
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            // Play the audio from the assigned AudioSource
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned to the button!");
        }
    }
}
