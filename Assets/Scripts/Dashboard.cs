using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
    public GameObject[] progressBars;
    public Color progress;

    public TextMeshProUGUI nPointsTo;
    public GameObject coupon;
    public GameObject merch;

    public GameObject filterTaskTick;
    public GameObject stageTaskTick;
    public GameObject guitarTaskTick;

    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToAR()
    {
        SceneManager.LoadScene("Blank");
    }
}
