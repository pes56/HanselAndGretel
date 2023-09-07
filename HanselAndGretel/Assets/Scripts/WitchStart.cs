using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchStart : MonoBehaviour
{
    public GameObject witch;

    public bool hasGivenLine = false;

    public float beginTimer = 0;

    //Time limit before object disappears
    public float endTime = 50.0f;

    [SerializeField] private AudioClip witchIntro;

    // Start is called before the first frame update
    void Start()
    {
        if (hasGivenLine == false)
        {
            SoundManager.Instance.PlaySound(witchIntro);
            hasGivenLine = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        InitialScene();
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
