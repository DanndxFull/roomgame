using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public AudioSource cameraSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ScreenCapture.CaptureScreenshot("screenshot.png");
            cameraSound.Play();
            Debug.Log("A screenshot was taken!");
        }
    }
}
