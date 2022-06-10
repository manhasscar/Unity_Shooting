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
    private BGMController bgmController; // ������� ���� (���� ���� �� ����)
    [SerializeField]
    private GameObject textBossWarnig; //���� ���� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject panelBossHP; // ���� ü�� �г� ������Ʈ
    [SerializeField]
    private GameObject boss;  //���� ������Ʈ
    [SerializeField]
    private float spawnTime; // �����Ǵ� �ֱ�
    [SerializeField]
    private int maxEnemyCount = 100;  //���� ���������� �ִ� �� ���� ����
    [SerializeField]
    private BackGroundCont[] backGroundcont;
    [SerializeField]
    private ConverCon[] converCon;

    private void Awake()
    {
        //���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        textBossWarnig.SetActive(false);
        // ���� ü�� �г� ��Ȱ��ȭ
        panelBossHP.SetActive(false);
        // ���� ������Ʈ ��Ȱ��ȭ
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");

    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0; //�� ���� ���� ī��Ʈ�� ����
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

                //�� ���� ����
                currentEnemyCount++;
                //���� �ִ� ���ڱ��� �����ϸ� �� ���� �ڷ�ƾ ����, ���� ���� �ڷ�ƾ ����
                if ( currentEnemyCount == maxEnemyCount )
                {
                    //��� �׶��̼� ����
                    backGroundcont[2].FadeOutBG();
                    backGroundcont[3].FadeOutBG();
                    backGroundcont[0].FadeInBG();
                    backGroundcont[1].FadeInBG();
                    yield return new WaitForSeconds(5.0f);
                    backGroundcont[2].sprite.sprite = backGroundcont[4].sprite.sprite;
                    backGroundcont[3].sprite.sprite = backGroundcont[4].sprite.sprite;            
                                       
                    backGroundcont[2].FadeInBG();
                    backGroundcont[3].FadeInBG();

                    converCon[0].AppearBox();
                    yield return new WaitForSeconds(3.0f);
                    converCon[0].sprite.sprite = converCon[1].sprite.sprite;
                    yield return new WaitForSeconds(3.0f);
                    converCon[0].DisAppearBox();


                    StartCoroutine("SpawnBoss");
                    break;
                }

                //spawnTime ��ŭ ���
                yield return new WaitForSeconds(spawnTime);
            }
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
    
    private IEnumerator SpawnBoss()
    {
        // ���� ���� BGM ����
        bgmController.ChangeBGM(BGMType.Boss); //����������

        yield return new WaitForSeconds(3.0f);

        // ���� ���� �ؽ�Ʈ Ȱ��ȭ
        textBossWarnig.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3.0f);

        //���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        textBossWarnig.SetActive(false);

        //���� ü�� �г� Ȱ��ȭ
        panelBossHP.SetActive(true);

        // ���� ������Ʈ Ȱ��ȭ
        boss.SetActive(true);

        //������ ù��° ������ ������ ��ġ�� �̵� ����
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
    
}
