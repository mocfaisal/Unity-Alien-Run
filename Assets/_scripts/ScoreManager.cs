using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    Text HighScoreUI;
    Text CurrScoreUI;
    int HighScoreInt;
    int CurrScoreInt;

    public ScoreManager()
    {
        instance = this;
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        HighScoreUI = GameObject.Find("High_Score_count").GetComponent<Text>();
        CurrScoreUI = GameObject.Find("Curr_Score_count").GetComponent<Text>();

        HighScoreInt = 0;
        CurrScoreInt = 0;

        HighScoreUI.text = HighScoreInt.ToString();
        CurrScoreUI.text = CurrScoreInt.ToString();
    }


    public void AddPoint()
    {
        CurrScoreInt++;
        CurrScoreUI.text = CurrScoreInt + "";
        Debug.Log(CurrScoreUI.text);
    }

}
