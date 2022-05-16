using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{
    private PlayerController playerController;
    private string scenName;

    public void Setup(PlayerController playerController, string sceneName)
    {
        this.playerController = playerController;
        this.scenName = sceneName;
    }


    private void OnDestroy()
    {
        // 보스 처치 +10000
        playerController.Score += 10000;
        // 플레이어 흭득 점수를 "Score" 키에 저장
        PlayerPrefs.SetInt("Score",playerController.Score);
        // sceneName으로 씬 변경
        SceneManager.LoadScene(scenName);
    }
}
