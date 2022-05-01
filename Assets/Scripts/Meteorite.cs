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
        //운석이 플레이어에게 닿을시
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            //폭발 이펙트
            //Instantiate(exlosionPrefab, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //운석 사망 처리 함수
            OnDie();
        }
    }

    public void OnDie()
    {
        //폭발 이펙트
        Instantiate(exlosionPrefab, transform.position, Quaternion.identity);
        //운석 사망
        Destroy(gameObject);
    }
}
