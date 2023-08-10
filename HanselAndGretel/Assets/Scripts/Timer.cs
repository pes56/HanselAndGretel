using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float startingTime;
    float currentTime;

    bool timerStarted = false;

    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject grandma;

    // Start is called before the first frame update
    void Start()
    {
        //countdownText.enabled = false;
        //grandma.activeInHierarchy = false;
        currentTime = startingTime;
        countdownText.text = currentTime.ToString();
        countdownText.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //countdownText.enabled = true;
            timerStarted = true;
        }

        if (timerStarted)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 3)
            {
                Debug.Log("Running out of time");
                countdownText.color = Color.red;
            }

            DisplayTime(startingTime);

            //countdownText.text = currentTime.ToString("f1");
        }
        
    }

    void CountdownIs0()
    {
        if(currentTime <= 0)
        {
            Debug.Log("timer reached zero");
            timerStarted = false;
            countdownText.enabled = false;
            //grandma.activeInHierarchy = false;
            currentTime = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{ 1:00}", minutes, seconds);
    }
}
