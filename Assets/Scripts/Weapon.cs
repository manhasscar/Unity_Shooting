using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; //발사체 프리펩
    [SerializeField]
    private float attackRate = 0.1f; //공격 속도
    [SerializeField]
    private int attackLevel = 1; //공격 레벨
    private int maxAttackLevel = 3; //최대 공격 레벨
    private AudioSource audioSource;
    [SerializeField]
    private GameObject boomPrefab; //폭탄 프리펩
    private int boomCount = 3; //생성 가능한 폭탄

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }

    public int BoomCount
    {
        set => boomCount = Mathf.Max(0, value);
        get => boomCount;
    }

    


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    public void StartBoom()
    {
        if (boomCount > 0)
        {
            boomCount--;
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //발사체 오브젝트 생성
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //공격 레벨에 따라 발사체 생성
            AttackByLevel();
            audioSource.Play();
            //attackRate 시간 만큼 대기
            yield return new WaitForSeconds(attackRate);
            
        }

    }
    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1: //레벨 1공격
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2: //레벨 2공격 전방으로 2개
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3: //레벨 3공격 3줄로
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                //왼쪽 대각선으로 발사
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                //오른쪽 대각선으로 발사
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;

        }
    }
}
