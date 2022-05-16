using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private AudioClip boomAudio; //폭탄 사운드
    private float boomDelay = 0.5f; //폭탄 이동시간
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

            //boomDelay에 설정된 시간동안 start 부터 end까지 이동
            //curve에 설정된 그래프처럼 빠르게 이동하다가 천천히 이동
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));
            
            yield return null;
        }

        //이동후 애니메이션 변경
        animator.SetTrigger("onBoom");
        //사운드 변경
        audioSource.clip = boomAudio;
        audioSource.Play();


    }

    public void OnBoom()
    {
        //게임 내에서 Enemy 태그를 가진 모든 오브젝트 정보를 가져온다
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //게임 내에서 Meteorite 태그를 가진 모든 오브젝트 정보를 가져온다
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");

        //모든 적 파괴
        for (int i = 0; i < enemys.Length; ++i)
        {
            enemys[i].GetComponent<Enemy>().OnDie();
        }

        //모든 운석 파괴
        for (int i = 0; i < meteorites.Length; ++i)
        {
            meteorites[i].GetComponent<Meteorite>().OnDie();
        }

        //폭탄 삭제

        Destroy(gameObject);

    }

}
