using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData; //�������� ũ�� ����
    [SerializeField]
    private GameObject enemyPrefab; //�� ĳ���� ������
    [SerializeField]
    private GameObject enemyHPSliderPrefab; //�� ü�� �����̴� ������
    [SerializeField]
    private Transform canvasTransform; //UI ǥ���ϴ� Canvas ������Ʈ transform
    [SerializeField]
    private float spawnTime; // �����Ǵ� �ֱ�



    private void Awake()
    {
        StartCoroutine("SpawnEnemy");

    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //x ��ġ�� �������� ũ�� ���� ������ ������ ���� ����
            //���� ��ġ���� ���� ������
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            // �� ĳ���� ������ġ
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            //�� ĳ���� ����
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //�� ü�� �����̴� ���� �� ����
            SpawnEnemyHPSlider(enemyClone);
            //spawnTime ��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }


    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        //�� ü���� ��Ÿ���� �����̴� UI ����
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        //�����̴� ������Ʈ�� ĵ������ �ڽ����� ����
        sliderClone.transform.SetParent(canvasTransform);
        //���� �������� �ٲ� ũ�⸦ �缳��
        sliderClone.transform.localScale = Vector3.one;

        //�����̴��� �i�ƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        //�����̴��� �ڽ��� ü�������� ǥ��
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}
