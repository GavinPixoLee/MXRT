using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public bool filterTask {  get; private set; }
    public bool stageTask {  get; private set; }
    public bool guitarTask { get; private set; }

    [SerializeField]
    int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FilterTaskComplete()
    {
        filterTask = true;
        points += 2;
    }
    public void StageTaskComplete()
    {
        stageTask = true;
        points += 2;
    }
    public void GuitarTaskComplete()
    {
        guitarTask = true;
        points += 2;
    }
}
