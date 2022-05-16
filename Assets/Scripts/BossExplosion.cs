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
        // ���� óġ +10000
        playerController.Score += 10000;
        // �÷��̾� ŉ�� ������ "Score" Ű�� ����
        PlayerPrefs.SetInt("Score",playerController.Score);
        // sceneName���� �� ����
        SceneManager.LoadScene(scenName);
    }
}
