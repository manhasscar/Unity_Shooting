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
        //����� moveDirection �������� moveSpeed �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //����� ������ �Ѿ�� ��ġ ������ �̵�

        if (transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }

    }
}
