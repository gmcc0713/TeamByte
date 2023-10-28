using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target; // 카메라가 따라갈 대상(플레이어)의 Transform 컴포넌트

    public float lerpTime = 1.0f; // 보간에 사용될 시간

    void Update()
    {
        if (target != null)
        {
            // 플레이어의 위치를 따라가도록 카메라의 위치를 업데이트합니다.
            //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

            // 타겟의 위치를 카메라의 x, y 좌표로 보간하여 새로운 위치 벡터를 생성
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // 현재 카메라의 위치에서 타겟의 위치로 보간을 적용하여 새로운 카메라의 위치를 계산
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);

        }
    }
}
