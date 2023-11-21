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
            // �÷��̾ ������ �巡�� ���� �� ����Ǵ� �ڵ�
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

        // ������ ����� �� ��ġ üũ �� �´� ��ġ�� �̵�
        CheckPosition();
    }

    void CheckPosition()
    {
        // ���⿡ �˸��� ��ġ üũ �� �̵� �ڵ带 �ۼ�
        // �´� ��ġ�� �������� ������ �ʱ� ��ġ�� ���ư�
    }

    public void ResetPosition()
    {
        // �ʱ� ��ġ�� ������ �����ϴ� �ڵ�
        transform.position = originalPosition;
    }
}
