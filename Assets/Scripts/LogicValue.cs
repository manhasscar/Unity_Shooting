using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicValue : MonoBehaviour
{



    public class ScoreData
    {
        public Text textRank;
        public string Name;
        public int Score;
    }
    [SerializeField]
    private static int m_Score;
    public static int Score { get { return m_Score; } }
    //textRank = GetComponent<Text>();
    //int m_Score = PlayerPrefs.GetInt("Score");



    public void scorereset()
    {
        m_Score = 0;
    }

    [SerializeField]
    private static List<ScoreData> m_ScoreArr;
    public static List<ScoreData> ScoreArr { get { return m_ScoreArr; } }

    public static void ScoreLoad()
    {
        m_ScoreArr = new List<ScoreData>();
        if (5 > m_ScoreArr.Count)
        {
            ScoreData NewScore1 = new ScoreData();
            NewScore1.Name = "ä��";
            NewScore1.Score = 54000;
            m_ScoreArr.Add(NewScore1);

            ScoreData NewScore2 = new ScoreData();
            NewScore2.Name = "����";
            NewScore2.Score = 36000;
            m_ScoreArr.Add(NewScore2);

            ScoreData NewScore3 = new ScoreData();
            NewScore3.Name = "�ڰ漷";
            NewScore3.Score = 29000;
            m_ScoreArr.Add(NewScore3);

        }
    }
    public static bool ScoreCheck()
    {
        //����� �˻��ؼ� ����
        //�� ����� �ǹ̰� ������ true�� �����Ѵ�.
        // ���� ����ִ� ���� �ִٸ� �����ϴ�.
        for (int i = 0; i < ScoreArr.Count; i++)
        {
            if (m_Score > ScoreArr[i].Score)
            {
                Debug.Log("���ο� ��� ture");
                return true;
            }
        }

        return false;
    }
}
