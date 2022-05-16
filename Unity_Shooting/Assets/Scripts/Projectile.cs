using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �±װ� enemy ��
        if (collision.CompareTag("Enemy"))
        {
            // �� ��� ó��
            //collision.GetComponent<Enemy>().OnDie();
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            //�߻�ü ����
            Destroy(gameObject);
        }
        else if ( collision.CompareTag("Boss"))
        {
            // �ε��� ������Ʈ ü�� ���� (����)
            collision.GetComponent<BossHP>().TakeDamage(damage);
            // �� ������Ʈ ���� (�߻�ü)
            Destroy (gameObject);
        }
    }
}
