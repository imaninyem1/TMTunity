using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject main_camera;
    public GameObject zoom_camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            main_camera.SetActive(!main_camera.activeSelf);
            zoom_camera.SetActive(!zoom_camera.activeSelf);
        }
    }
}
