using UnityEngine;

public enum BGMType { Stage = 0 , Boss }

public class BGMController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] bgmClips; //������� ���� ���
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ChangeBGM(BGMType index)
    {
        //���� ��� ���� ������� ����
        audioSource.Stop();


        //��� ���� ���� ��Ͽ��� index��° ����������� ���� ��ü
        audioSource.clip = bgmClips[(int)index];
        //�ٲ� ������� ���
        audioSource.Play();
    }
}
