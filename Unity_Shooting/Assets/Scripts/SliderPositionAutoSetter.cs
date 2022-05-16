using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 35.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;


    public void Setup(Transform target)
    {
        //�����̴��� ���� Ÿ�� ����
        targetTransform = target;
        //recttransform ������Ʈ ���� ������
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        //���� ������� �����̴��� �����
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }
        //ȭ�鿡�� ��ǥ���� ����
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        //ȭ�鳻�� ��ǥ + �Ÿ���ŭ ������ ��ġ�� �����̴� ui ��ġ�� ����
        rectTransform.position = screenPosition + distance;
    }
    
}
