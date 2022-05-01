using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private GameObject exlosionPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //��� �÷��̾�� ������
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            //���� ����Ʈ
            //Instantiate(exlosionPrefab, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //� ��� ó�� �Լ�
            OnDie();
        }
    }

    public void OnDie()
    {
        //���� ����Ʈ
        Instantiate(exlosionPrefab, transform.position, Quaternion.identity);
        //� ���
        Destroy(gameObject);
    }
}
