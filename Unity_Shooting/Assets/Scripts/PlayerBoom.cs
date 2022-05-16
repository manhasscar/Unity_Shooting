using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private AudioClip boomAudio; //��ź ����
    [SerializeField]
    private int damage = 100; //��ź ������
    private float boomDelay = 0.5f; //��ź �̵��ð�
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine("MoveToCenter");
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;

        while (percent <1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;

            //boomDelay�� ������ �ð����� start ���� end���� �̵�
            //curve�� ������ �׷���ó�� ������ �̵��ϴٰ� õõ�� �̵�
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));
            
            yield return null;
        }

        //�̵��� �ִϸ��̼� ����
        animator.SetTrigger("onBoom");
        //���� ����
        audioSource.clip = boomAudio;
        audioSource.Play();


    }

    public void OnBoom()
    {
        //���� ������ Enemy �±׸� ���� ��� ������Ʈ ������ �����´�
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //���� ������ Meteorite �±׸� ���� ��� ������Ʈ ������ �����´�
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");

        //��� �� �ı�
        for (int i = 0; i < enemys.Length; ++i)
        {
            enemys[i].GetComponent<Enemy>().OnDie();
        }

        //��� � �ı�
        for (int i = 0; i < meteorites.Length; ++i)
        {
            meteorites[i].GetComponent<Meteorite>().OnDie();
        }

        //���� ���� ���� �����ϴ� ��, ������ �߻�ü�� ��� �ı�
        GameObject[] projectils = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        for (int i = 0; i < projectils.Length; ++ i)                 //EnemyProjectile
        {
            projectils[i].GetComponent<EnemyProjectile>().Ondie();
        }

        // ���� ���� ������ "Boss" �±׸� ���� ������Ʈ ������ �����´�
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            // ������ ü���� damage��ŭ ���ҽ�Ų��
            boss.GetComponent<BossHP>().TakeDamage(damage);
        }

        //��ź ����
        Destroy(gameObject);

    }

}
