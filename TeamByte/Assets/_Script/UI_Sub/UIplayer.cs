using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIplayer : MonoBehaviour
{
    public float moveSpeed = 15f; // 움직임 속도를 조절할 변수

    void Update()
    {
        // WASD 키 입력을 받아 움직임 처리
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 움직임 방향을 구합니다.
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // 현재 게임 오브젝트의 위치를 얻어오고 이동 방향과 속도를 곱하여 새로운 위치를 계산합니다.
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;

        // 새로운 위치로 이동합니다.
        transform.position = newPosition;
    }
}