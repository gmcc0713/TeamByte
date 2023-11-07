using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PuzzlePiece : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int snapOffset = 30;
    public GameObject[] piecePositions; // �迭�� ���� ������ �˸´� ��ġ�� ����
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // ���� ������ �ʱ� ��ġ ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bool snapped = false; // ���� ������ ��򰡿� '������' ��츦 ��Ÿ���� �÷���

        // ��� ���� ��ġ�� ���� ������ �����Ͽ� ���� ����� ��ġ�� ã��
        for (int i = 0; i < piecePositions.Length; i++)
        {
            if (Vector3.Distance(piecePositions[i].transform.position, transform.position) < snapOffset)
            {
                transform.SetParent(piecePositions[i].transform);
                transform.position = piecePositions[i].transform.position;
                snapped = true; // ���� ������ ��ġ�� '������'
                break; // ���� ����� ��ġ�� ã�����Ƿ� ���� ����
            }
        }

        if (!snapped)
        {
            // � ��ġ���� '��������' �ʾ����Ƿ� �ʱ� ��ġ�� �ǵ���
            transform.position = initialPosition;
        }
    }
}
