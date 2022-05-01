using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;         //최대 체력
    private float currentHP;          //현재 체력
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;


    public float MaxHP => maxHP;        // maxHP 변수에 접근할수있는 프로퍼티
    public float CurrentHP
    {
        set => currentHP = Mathf.Clamp(value, 0, maxHP);
        get => currentHP;
    } // currentHP 변수에 접근 프로퍼티
    //외부에서 접근


    private void Awake()
    {
        currentHP = maxHP;              //현재 체력을 최대 체력과 같게 설정
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();

    }

    public void TakeDamage(float damage)
    {
        //현재 체력을 damage만큼 감소
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //체력이 0이하 = 플레이어 캐릭터 사망
        if (currentHP <= 0)
        {
            Debug.Log("Player HP : 0..Die");
            playerController.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    /*
    private IEnumerable HitColorAnimation()
    {
        // 플레이어의 색상을 빨간색으로
        spriteRenderer.color = Color.red;   
        //0.1초 대기 
        yield return new WaitForSeconds(0.1f);
        //플레이어의 색상을 원랙 색상인 하얀색으로 변경
        //원래색이 하얀색 x -> 원래 색상 변수 선언
        spriteRenderer.color = Color.white;
    }
    */

}
