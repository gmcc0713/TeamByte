using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PuzzlePiece : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int snapOffset = 30;
    public GameObject[] piecePositions; // 배열로 퍼즐 조각이 알맞는 위치를 저장
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // 퍼즐 조각의 초기 위치 저장
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool snapped = false; // 퍼즐 조각이 어딘가에 '끼워질' 경우를 나타내는 플래그

        // 모든 퍼즐 위치에 대해 루프를 실행하여 가장 가까운 위치를 찾음
        for (int i = 0; i < piecePositions.Length; i++)
        {
            if (Vector3.Distance(piecePositions[i].transform.position, transform.position) < snapOffset)
            {
                transform.SetParent(piecePositions[i].transform);
                transform.position = piecePositions[i].transform.position;
                snapped = true; // 퍼즐 조각이 위치에 '끼워짐'
                break; // 가장 가까운 위치를 찾았으므로 루프 종료
            }
        }

        if (!snapped)
        {
            // 어떤 위치에도 '끼워지지' 않았으므로 초기 위치로 되돌림
            transform.position = initialPosition;
        }
    }
}
