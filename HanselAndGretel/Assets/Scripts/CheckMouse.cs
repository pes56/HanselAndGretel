using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouse : MonoBehaviour
{
    public AudioSource soundPlayer;

    Camera camera;
    Plane[] cameraFrustum;
    Collider collider;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds) && Input.GetMouseButtonDown(0))
        {
            playThisSoundEffect();
        }
        //if (Input.GetMouseButtonDown(0))
        //{
           //playThisSoundEffect();
        //}
    }
    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }

}
