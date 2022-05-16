using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;

    private void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        // stage에서 지정한 점수를 불러와서 score 변수에 저장

        int score = PlayerPrefs.GetInt("Score");
        // textResultScore UI에 점수 갱신
        textResultScore.text = "Result Score " + score;
    }
}
