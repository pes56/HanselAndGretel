using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitApplication()
    {
        Debug.Log("I exited this program.");
        Application.Quit();
    }
}
