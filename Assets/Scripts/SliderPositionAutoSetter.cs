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
        //슬라이더가 따라갈 타겟 설정
        targetTransform = target;
        //recttransform 컴포넌트 정보 얻어오기
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        //적이 사라지면 슬라이더도 사라짐
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }
        //화면에서 좌표값을 구함
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        //화면내의 좌표 + 거리만큼 떨어진 위치를 슬라이더 ui 위치로 설정
        rectTransform.position = screenPosition + distance;
    }
    
}
