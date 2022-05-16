using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private float destroyWeight = 2.0f;


    private void LateUpdate()

    {
        //오브젝트가 맵의 범위를 벗어나면 삭제됨..
        //삭제가 안되면 계속 오브젝트가 계속 쌓여서 메모리 마구 잡아먹음
        if (transform.position.y < stageData.LimitMin.y - destroyWeight ||
            transform.position.y > stageData.LimitMax.y + destroyWeight ||
            transform.position.x < stageData.LimitMin.x - destroyWeight ||
            transform.position.x > stageData.LimitMax.x + destroyWeight)
        {
            Destroy(gameObject);
        }
    }
}
