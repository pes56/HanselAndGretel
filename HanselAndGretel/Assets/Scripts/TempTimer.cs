using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempTimer : MonoBehaviour
{
    //References HeavyMechanic script
    HeavyMechanic heavyMechanic; //Empty field to hold HeavyMechanic script
    [SerializeField] GameObject movableObject;

    //Time to countdown from
    public float timeValue = 90;
    [SerializeField] TMP_Text timerText;

    public GameObject clock;

    //For the appearance of clock
    private float startTimer = 0;

    //Time limit before clock appears
    private float clockShowTime = 50.0f;

    private void Awake()
    {
        heavyMechanic = movableObject.GetComponent<HeavyMechanic>(); //Gets the script components
    }

    // Start is called before the first frame update
    void Start()
    {
        //Checks to see if clock is in the scene
        if (clock != null)
        {
            clock.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();

        DisplayTime(timeValue);

    }

    //Checks if the object is moved and makes the clock appear and countdown
    void StartTimer()
    {
        if (heavyMechanic.targetPosition != heavyMechanic.currentPosition)
        {
            startTimer += Time.fixedDeltaTime;
            if (startTimer >= clockShowTime)
            {
                clock.SetActive(true);

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
                    clock.SetActive(false);
                }
            }
        }
    }

    //Shows the clock in minutes and seconds
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
