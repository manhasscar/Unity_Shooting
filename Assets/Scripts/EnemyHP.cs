using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 4; //최대 체력
    private float currentHP; //현재 체력
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float damage)
    {
        //현재 체력을 damage 만큼 감소
        currentHP -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        //체력이 0이하시 플레이어 사망
        if(currentHP <= 0)
        {
            //적캐릭터 사망
            enemy.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        //적의 색상을 빨강으로
        spriteRenderer.color = Color.red;
        //0.05초간 대기
        yield return new WaitForSeconds(0.05f);
        //원래 색으로 돌리기
        spriteRenderer.color = Color.white;
    }

}
