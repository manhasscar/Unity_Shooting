using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject explosionPrefab; // ����ȿ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �߻�ü�� �΋H�� ������Ʈ�� �±װ� "Player"�̸�
        if (collision.CompareTag("Player"))
        {
            // �ε��� ������Ʈ ü�� ���� (�÷��̾�)
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ������Ʈ ���� (�߻�ü)
            Destroy(gameObject);

        }
    }

    public void Ondie()
    {
        // ���� ȿ�� ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ��/���� �߻�ü ����
        Destroy(gameObject);

    }


}
