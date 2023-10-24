using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target; // 카메라가 따라갈 대상(플레이어)의 Transform 컴포넌트

    void Update()
    {
        if (target != null)
        {
            // 플레이어의 위치를 따라가도록 카메라의 위치를 업데이트합니다.
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
