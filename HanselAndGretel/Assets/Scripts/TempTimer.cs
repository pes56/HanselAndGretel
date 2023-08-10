using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempTimer : MonoBehaviour
{
    public float timeValue = 90;
    [SerializeField] TMP_Text timerText;

    public 
    

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else if (timeValue <= 3)
        {
            Debug.Log("Running out of time");
            timerText.color = Color.red;
        }
        else if (timeValue == 0)
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
