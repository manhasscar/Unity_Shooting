using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin;

    [SerializeField]
    private Vector2 limitMax;

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
}
/*
 * 현재 스테이지의 범위 설정
 * 에셋 데이터로 저장해두고 정보를 불러옴
 */