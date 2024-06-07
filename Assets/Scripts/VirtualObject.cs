using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualObject : MonoBehaviour
{
    public bool scanned;
    public string task;
    public GameObject[] infoOnly;
    public GameObject filter;
    ScoreCounter scoreCounter;
    public ARCameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scanned && !scoreCounter.CheckComplete(task)) { 
            GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().TaskComplete(task);
        }
        foreach (GameObject infoObject in infoOnly)
        {
            if (cameraController.infoMode)
            {
                infoObject.SetActive(true);
                filter.SetActive(false);
            }
            else
            {
                infoObject.SetActive(false);
                filter.SetActive(true);
            }
        }
    }
}
