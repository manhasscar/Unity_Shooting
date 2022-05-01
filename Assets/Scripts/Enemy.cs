using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 100; // �� óġ�� ����
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��
    [SerializeField]
    private GameObject[] itemPrefabs; //���� ���϶� ȹ�� ������ ������

    private PlayerController playerController; // �÷��̾� ������ ����

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ �ε��� ������Ʈ �±װ� �÷��̾� �Ͻ� �����
        if (collision.CompareTag("Player"))
        {   //�� ���ݷ� ��ŭ �÷��̾� HP ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            //�� ���
            OnDie();
        }
    }

    public void OnDie()
    {
        //�÷��̾� ������ ���ھ�����Ʈ ��ŭ ����
        playerController.Score += scorePoint;
        //���� ����Ʈ
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //���� Ȯ���� ������ ����
        SpawnItem();
        //�� ������Ʈ ����
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        //�Ŀ���(10%)
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if(spawnItem < 15)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        else if(spawnItem < 30)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
        
    }
}
