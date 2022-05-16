using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float scrollRange = 9.9f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;
   
    void Update()
    {
        //배경이 moveDirection 방향으로 moveSpeed 속도로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //배경이 범위를 넘어가면 위치 앞으로 이동

        if (transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }

    }
}
