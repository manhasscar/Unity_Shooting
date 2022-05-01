using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; //스테이지 크기 정보
    [SerializeField]
    private GameObject enemyPrefab; //적 캐릭터 프리펩
    [SerializeField]
    private GameObject enemyHPSliderPrefab; //적 체력 슬라이더 프리펩
    [SerializeField]
    private Transform canvasTransform; //UI 표현하는 Canvas 오브젝트 transform
    [SerializeField]
    private float spawnTime; // 생성되는 주기



    private void Awake()
    {
        StartCoroutine("SpawnEnemy");

    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //x 위치는 스테이지 크기 범위 내에서 임의의 값을 선택
            //랜덤 위치에서 적이 생성됨
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            // 적 캐릭터 생성위치
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            //적 캐릭터 생성
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //적 체력 슬라이더 생성 및 설정
            SpawnEnemyHPSlider(enemyClone);
            //spawnTime 만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }


    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        //적 체력을 나타내는 슬라이더 UI 생성
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        //슬라이더 오브젝트를 캔버스의 자식으로 설정
        sliderClone.transform.SetParent(canvasTransform);
        //계층 설정으로 바뀐 크기를 재설정
        sliderClone.transform.localScale = Vector3.one;

        //슬라이더가 쫒아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        //슬라이더에 자신의 체력정보를 표시
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}
