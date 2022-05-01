using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적의 태그가 enemy 면
        if (collision.CompareTag("Enemy"))
        {
            // 적 사망 처리
            //collision.GetComponent<Enemy>().OnDie();
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            //발사체 삭제
            Destroy(gameObject);
        }
    }
}
