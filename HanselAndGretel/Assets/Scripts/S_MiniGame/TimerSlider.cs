using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSlider : MonoBehaviour
{
    public Image timer_linear_image;
    float time_remaining;
    public float max_time = 10.0f;

    void Start()
    {
        time_remaining = max_time;
    }

    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer_linear_image.fillAmount = time_remaining / max_time;
        }
        else
        {
            // Transition to the "BadEnding" scene
            SceneManager.LoadScene("BadEnding");
        }
    }
}
