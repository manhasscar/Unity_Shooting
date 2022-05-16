using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject alertLinePrefab;
    [SerializeField]
    private GameObject meteoritePrefab;
    [SerializeField]
    private float minSpawnTime = 1.0f;
    [SerializeField]
    private float maxSpawnTime = 4.0f;

    private void Awake()
    {
        StartCoroutine("SpawnMeteorite");
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            //랜덤한 위치에서 생성
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            //얼럿라인 생성
            GameObject alertLineClone = Instantiate(alertLinePrefab, new Vector3(positionX, 0, 0), Quaternion.identity);

            yield return new WaitForSeconds(1.0f);

            //경고선 삭제
            Destroy(alertLineClone);

            Vector3 meteoritePostion = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0);
            Instantiate(meteoritePrefab, meteoritePostion, Quaternion.identity);

            //대기 시간 설정

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            //해당 시간 만큼 대기후 다음 로직 실행

            yield return new WaitForSeconds(spawnTime);

        }

    }
}
