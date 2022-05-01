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
        //score ���� ������ ���� �ʵ���
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
        // �÷��̾ ����� ���� �Ҵ�
        if (isDie == true) return;
        //�̵� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        //����Ű ��/�ٿ����� ���� ���۰� ����
        if (Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }

        //��ź Ű�� ���� ��ź ����
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
        //�̵� ���� �ʱ�ȭ
        movement2D.MoveTo(Vector3.zero);
        //��� �ִϸ��̼� ���
        animator.SetTrigger("onDie");
        //�浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        //����� ���� �Ҵ�
        isDie = true;
    }

    public void OnDieEvent()
    {
        //��⿡ ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        //�÷��̾� ����� nextScenName���� �̵�
        SceneManager.LoadScene(nextScenName);
    }
}
