using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; //�߻�ü ������
    [SerializeField]
    private float attackRate = 0.1f; //���� �ӵ�
    [SerializeField]
    private int attackLevel = 1; //���� ����
    private int maxAttackLevel = 3; //�ִ� ���� ����
    private AudioSource audioSource;
    [SerializeField]
    private GameObject boomPrefab; //��ź ������
    private int boomCount = 3; //���� ������ ��ź

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
            //�߻�ü ������Ʈ ����
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //���� ������ ���� �߻�ü ����
            AttackByLevel();
            audioSource.Play();
            //attackRate �ð� ��ŭ ���
            yield return new WaitForSeconds(attackRate);
            
        }

    }
    private void AttackByLevel()
    {
        GameObject cloneProjectile = null;

        switch (attackLevel)
        {
            case 1: //���� 1����
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                break;
            case 2: //���� 2���� �������� 2��
                Instantiate(projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3: //���� 3���� 3�ٷ�
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                //���� �밢������ �߻�
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(-0.2f, 1, 0));
                //������ �밢������ �߻�
                cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement2D>().MoveTo(new Vector3(0.2f, 1, 0));
                break;

        }
    }
}
