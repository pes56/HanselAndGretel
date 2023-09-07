using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WitchCheck : MonoBehaviour
{
    //References HeavyMechanic script
    HeavyMechanic heavyMechanic; //Empty field to hold HeavyMechanic script
    [SerializeField] GameObject movableObject;

    //References ToggleImageOnClick script
    ToggleImageOnClick toggleImageOnClick; //Empty field to hold ToggleImageOnClick script
    [SerializeField] GameObject imageOnCouch;

    public GameObject witch;
    //private Animation anim;

    //Accesses the sprite to change to
    public SpriteRenderer spriteRenderer;
    public Sprite[] witchSprite;

    //Her lines to play when object moves
    [SerializeField] private AudioClip witchIntro;
    [SerializeField] private AudioClip witchLVL1;
    [SerializeField] private AudioClip witchLVL2;
    [SerializeField] private AudioClip witchLVL3;

    public bool hasGivenLine = false;

    private float startTimer = 0;

    //Time limit before witch appears
    private float witchShowTime = 50.0f;

    public float beginTimer = 0;

    //Time limit before object disappears
    public float endTime = 50.0f;

    //Check how many times an object moved activated
    private int timeMoved = 0;

    private void Awake()
    {
        heavyMechanic = movableObject.GetComponent<HeavyMechanic>(); //Gets the script components
    }

    // Start is called before the first frame update
    void Start()
    {
        if (hasGivenLine == false)
        {
            SoundManager.Instance.PlaySound(witchIntro);
            hasGivenLine = true;
        }

        //anim = GetComponent<Animation>();
        
        //Checks to see if she is in the scene
        //if (witch != null)
        //{
            //witch.gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckObject();
    }

    void CheckObject()
    {
        if (heavyMechanic.targetPosition != heavyMechanic.currentPosition)
        {
            timeMoved += 1;
            startTimer += Time.fixedDeltaTime;

            //Plays sound during time counting to signal witch
            //if (timeMoved == 1)
            //{
            //    SoundManager.Instance.PlaySound(witchLVL1);
            //} 
            //else if(timeMoved == 2)
            //{
            //    SoundManager.Instance.PlaySound(witchLVL2);
            //}
            //else if (timeMoved >= 3)
            //{
            //    SoundManager.Instance.PlaySound(witchLVL3);
            //}
            
            //The timer ends and the witch shows up in form
            if (startTimer >= witchShowTime && timeMoved == 1)
            {
                if (SceneManager.GetActiveScene().name == "HallWay")
                {
                    witch.SetActive(true);
                }
                else
                {
                    inRightRoom();
                }
            }
            
            if (startTimer >= witchShowTime && timeMoved == 2)
            {
                if (SceneManager.GetActiveScene().name == "HallWay")
                {
                    witch.SetActive(true);
                    spriteRenderer.sprite = witchSprite[0];
                }
                else
                {
                    inRightRoom();
                }
            }

            if(startTimer >= witchShowTime && timeMoved >= 3)
            {
                if (SceneManager.GetActiveScene().name == "HallWay")
                {
                    witch.SetActive(true);
                    spriteRenderer.sprite = witchSprite[1];
                }
                else
                {
                    inRightRoom();
                }
            }
        } 
    }

    void inRightRoom()
    {
        if (SceneManager.GetActiveScene().name != "HallWay")
        {
            SceneManager.LoadScene("BadEnding");
        }

        if (toggleImageOnClick.isImageVisible == false)
        {
            SceneManager.LoadScene("BadEnding");
        }
    }

    void InitialScene()
    {
        beginTimer += Time.fixedDeltaTime;
        if (beginTimer >= endTime)
        {
            witch.SetActive(false);
        }
    }
}
