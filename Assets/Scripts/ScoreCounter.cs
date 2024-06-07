using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public bool loggedIn;
    public bool filterTask {  get; private set; }
    public bool stageTask {  get; private set; }
    public bool guitarTask { get; private set; }

    public int points { get; private set; }

    public static ScoreCounter Instance;

    private void Awake()
    {
        loggedIn = false;
        points = 0;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool CheckComplete(string task)
    {
        if (task.Equals("stage"))
        {
            return stageTask;
        }
        else if (task.Equals("guitar"))
        {
            return guitarTask;
        }
        else if (task.Equals("filter"))
        {
            return filterTask;
        }
        else
        {
            return false;
        }
    }
    public void TaskComplete(string task)
    {
        if (task.Equals("stage"))
        {
            stageTask = true;
        }
        else if (task.Equals("guitar"))
        {
            guitarTask = true;
        }
        else if (task.Equals("filter"))
        {
            filterTask = true;
        }
        points += 2;
    }
}
