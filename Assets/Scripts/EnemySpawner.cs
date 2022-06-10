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
    private BGMController bgmController; // 배경음악 설정 (보스 등장 시 변경)
    [SerializeField]
    private GameObject textBossWarnig; //보스 등장 텍스트 오브젝트
    [SerializeField]
    private GameObject panelBossHP; // 보스 체력 패널 오브젝트
    [SerializeField]
    private GameObject boss;  //보스 오브젝트
    [SerializeField]
    private float spawnTime; // 생성되는 주기
    [SerializeField]
    private int maxEnemyCount = 100;  //현재 스테이지의 최대 적 생성 숫자
    [SerializeField]
    private BackGroundCont[] backGroundcont;
    [SerializeField]
    private ConverCon[] converCon;

    private void Awake()
    {
        //보스 등장 텍스트 비활성화
        textBossWarnig.SetActive(false);
        // 보스 체력 패널 비활성화
        panelBossHP.SetActive(false);
        // 보스 오브젝트 비활성화
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");

    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0; //적 생성 숫자 카운트용 변수
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

                //적 생성 숫자
                currentEnemyCount++;
                //적을 최대 숫자까지 생성하면 적 생성 코루틴 중지, 보스 생성 코루틴 실행
                if ( currentEnemyCount == maxEnemyCount )
                {
                    //배경 그라데이션 등장
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

                //spawnTime 만큼 대기
                yield return new WaitForSeconds(spawnTime);
            }
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
    
    private IEnumerator SpawnBoss()
    {
        // 보스 등장 BGM 설정
        bgmController.ChangeBGM(BGMType.Boss); //가독성좋음

        yield return new WaitForSeconds(3.0f);

        // 보스 등장 텍스트 활성화
        textBossWarnig.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3.0f);

        //보스 등장 텍스트 비활성화
        textBossWarnig.SetActive(false);

        //보스 체력 패널 활성화
        panelBossHP.SetActive(true);

        // 보스 오브젝트 활성화
        boss.SetActive(true);

        //보스의 첫번째 상태인 지정된 위치로 이동 실행
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
    
}
