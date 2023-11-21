using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            // 플레이어가 조각을 드래그 중일 때 실행되는 코드
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // 조각을 드롭한 후 위치 체크 및 맞는 위치로 이동
        CheckPosition();
    }

    void CheckPosition()
    {
        // 여기에 알맞은 위치 체크 및 이동 코드를 작성
        // 맞는 위치에 도달하지 않으면 초기 위치로 돌아감
    }

    public void ResetPosition()
    {
        // 초기 위치로 조각을 리셋하는 코드
        transform.position = originalPosition;
    }
}
