using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 4; //�ִ� ü��
    private float currentHP; //���� ü��
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
        //���� ü���� damage ��ŭ ����
        currentHP -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        //ü���� 0���Ͻ� �÷��̾� ���
        if(currentHP <= 0)
        {
            //��ĳ���� ���
            enemy.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        //���� ������ ��������
        spriteRenderer.color = Color.red;
        //0.05�ʰ� ���
        yield return new WaitForSeconds(0.05f);
        //���� ������ ������
        spriteRenderer.color = Color.white;
    }

}
