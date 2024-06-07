using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dashboard : MonoBehaviour
{
    public GameObject login;
    public GameObject instructions;
    public GameObject dashboard;


    public GameObject[] progressBars;
    public Color progress;

    public TextMeshProUGUI nPointsTo;
    public GameObject coupon;
    public GameObject merch;
    public GameObject completion;

    public GameObject filterTaskTick;
    public GameObject stageTaskTick;
    public GameObject guitarTaskTick;

    ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        if (scoreCounter.loggedIn)
        {
            login.SetActive(false);
            instructions.SetActive(false);
            dashboard.SetActive(true);
        }
        else
        {
            login.SetActive(true);
            instructions.SetActive(false);
            dashboard.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scoreCounter.points; i++)
        {
            progressBars[i].GetComponent<Image>().color = progress;
        }

        int remainingPoints = 3 - scoreCounter.points % 3;
        nPointsTo.text = remainingPoints.ToString() + (remainingPoints == 1 ? " point" : " points") + " away from";

        if (scoreCounter.points < 3)
        {
            nPointsTo.gameObject.SetActive(true);
            coupon.SetActive(true);
            merch.SetActive(false);
            completion.SetActive(false);
        }
        else if (scoreCounter.points < 6)
        {
            nPointsTo.gameObject.SetActive(true);
            coupon.SetActive(false);
            merch.SetActive(true);
            completion.SetActive(false);
        }
        else
        {
            nPointsTo.gameObject.SetActive(false);
            coupon.SetActive(false);
            merch.SetActive(false);
            completion.SetActive(true);
        }

        if (scoreCounter.filterTask)
        {
            filterTaskTick.SetActive(true);
        }
        if (scoreCounter.stageTask)
        {
            stageTaskTick.SetActive(true);
        }
        if (scoreCounter.guitarTask)
        {
            guitarTaskTick.SetActive(true);
        }
    }

    public void GoToAR()
    {
        SceneManager.LoadScene("BlankAR");
    }

    public void TransitionScreen(string nextScreen)
    {
        if (string.Equals(nextScreen, "instructions"))
        {
            login.SetActive(false);
            instructions.SetActive(true);
            dashboard.SetActive(false);
        }
        else if (string.Equals(nextScreen, "dashboard")){
            login.SetActive(false);
            instructions.SetActive(false);
            dashboard.SetActive(true);
            scoreCounter.loggedIn = true;
        }
    }
}
