using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 100; // 적 처치시 점수
    [SerializeField]
    private GameObject explosionPrefab; // 폭발 효과
    [SerializeField]
    private GameObject[] itemPrefabs; //적을 죽일때 획득 가능한 아이템

    private PlayerController playerController; // 플레이어 점수에 접근

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적에게 부딪힌 오브젝트 태그가 플레이어 일시 적사망
        if (collision.CompareTag("Player"))
        {   //적 공격력 만큼 플레이어 HP 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            //적 사망
            OnDie();
        }
    }

    public void OnDie()
    {
        //플레이어 점수를 스코어포인트 만큼 증가
        playerController.Score += scorePoint;
        //폭발 이펙트
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //일정 확률오 아이템 생성
        SpawnItem();
        //적 오브젝트 제거
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        //파워업(10%)
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
