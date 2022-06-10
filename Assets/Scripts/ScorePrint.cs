using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour
{
    Text[] ArrText = null;

    //public Text textRank; 

    [SerializeField]
    GameObject NamelnputObj = null;

    void Awake()
    {
        LogicValue.ScoreLoad();

        //textRank = GetComponent<Text>();
        //int m_Score = PlayerPrefs.GetInt("Score");


        if (null == NamelnputObj)
        {
            Debug.LogError("if (null == NamelnputObj)");
            return;
        }

        if (true == LogicValue.ScoreCheck())
        {
            NamelnputObj.SetActive(true);
        }


        //if (true == LogicValue.Score)
        //LogicValue.ScoreCheck();



    }

    // Update is called once per frame
    void Update()
    {
        ArrText = GetComponentsInChildren<Text>();

        if (LogicValue.ScoreArr.Count != ArrText.Length)
        {
            Debug.LogError("if(LogicValue.ScoreArr.Count != ArrText.Length)");
            return;
        }

        for (int i = 0; i < ArrText.Length; i++)
        {
            if (LogicValue.ScoreArr[i].Name == "")
            {
                ArrText[i].text = "¹Ìµî·Ï";
                continue;

            }

            ArrText[i].text =
                (i + 1).ToString() + "." + LogicValue.ScoreArr[i].Name
                + " " + LogicValue.ScoreArr[i].Score.ToString();
        }

    }
}
