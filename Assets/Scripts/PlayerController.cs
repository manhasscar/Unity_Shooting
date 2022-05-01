using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextScenName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.Z;
    private Weapon weapon;
    private bool isDie = false;
    private Movement2D movement2D;
    private Animator animator;

    private int score;
    public int Score
    {
        //score 값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;

    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // 플레이어가 사망시 조작 불능
        if (isDie == true) return;
        //이동 방향
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        //공격키 업/다운으로 공격 시작과 종료
        if (Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }

        //폭탄 키를 눌러 폭탄 생성
        if (Input.GetKeyDown(keyCodeBoom))
        {
            weapon.StartBoom();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
    public void OnDie()
    {
        //이동 방향 초기화
        movement2D.MoveTo(Vector3.zero);
        //사망 애니메이션 재생
        animator.SetTrigger("onDie");
        //충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        //사망시 조작 불능
        isDie = true;
    }

    public void OnDieEvent()
    {
        //기기에 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);
        //플레이어 사망시 nextScenName으로 이동
        SceneManager.LoadScene(nextScenName);
    }
}
