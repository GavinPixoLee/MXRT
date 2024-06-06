using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARCameraController : MonoBehaviour
{
    bool recording;
    bool infoMode;

    public GameObject dashboard;
    public GameObject toggleMode;
    public GameObject shutter;
    public GameObject record;
    public GameObject whiteScreen;

    public GameObject redCircle;
    public GameObject whiteSquare;
    public GameObject cameraIcon;
    public GameObject infoIcon;
    // Start is called before the first frame update
    void Start()
    {
        infoMode = true;
        recording = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (infoMode) //If we are in info mode
        {
            //These two are active
            dashboard.SetActive(true);
            toggleMode.SetActive(true);
            //Show the camera icon instead of the info icon for the toggle icon
            cameraIcon.SetActive(true);
            infoIcon.SetActive(false);
            //Deactivate the photo and video recording button
            shutter.SetActive(false);
            record.SetActive(false);
        }
        else //If we are in camera mode
        {
            cameraIcon.SetActive(false);
            infoIcon.SetActive(true);
            if (recording) //If we are recording
            {
                //These two will be inactive to prevent recording interruption
                dashboard.SetActive(false);
                toggleMode.SetActive(false);
                //Deactivate the photo taking button
                shutter.SetActive(false);
                //Activate the video recording button
                record.SetActive(true);
                //Change the recording button icon to white square instead of red circle
                redCircle.SetActive(false);
                whiteSquare.SetActive(true);
            }
            else //If we are not recording
            {
                //These two will be active
                dashboard.SetActive(true);
                toggleMode.SetActive(true);
                //Activate the photo taking button
                shutter.SetActive(true);
                //Activate the video recording button
                record.SetActive(true);
                //Change the recording button icon to red circle instead of white square
                redCircle.SetActive(true);
                whiteSquare.SetActive(false);
            }
        }
    }

    public void ToggleMode()
    {
        infoMode = !infoMode;
    }
    public void ToggleRecording()
    {
        recording = !recording;
    }
    public void TakePhoto()
    {
        whiteScreen.GetComponent<Animation>().Play();
    }
    public void GoToDashboard()
    {
        SceneManager.LoadScene("Menu");
    }
}
