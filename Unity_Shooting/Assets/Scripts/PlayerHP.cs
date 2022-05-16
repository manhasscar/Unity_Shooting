using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;         //�ִ� ü��
    private float currentHP;          //���� ü��
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;


    public float MaxHP => maxHP;        // maxHP ������ �����Ҽ��ִ� ������Ƽ
    public float CurrentHP
    {
        set => currentHP = Mathf.Clamp(value, 0, maxHP);
        get => currentHP;
    } // currentHP ������ ���� ������Ƽ
    //�ܺο��� ����


    private void Awake()
    {
        currentHP = maxHP;              //���� ü���� �ִ� ü�°� ���� ����
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();

    }

    public void TakeDamage(float damage)
    {
        //���� ü���� damage��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0���� = �÷��̾� ĳ���� ���
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
        // �÷��̾��� ������ ����������
        spriteRenderer.color = Color.red;   
        //0.1�� ��� 
        yield return new WaitForSeconds(0.1f);
        //�÷��̾��� ������ ���� ������ �Ͼ������ ����
        //�������� �Ͼ�� x -> ���� ���� ���� ����
        spriteRenderer.color = Color.white;
    }
    */

}
