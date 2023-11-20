using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIplayer : MonoBehaviour
{
    public float moveSpeed = 15f; // ������ �ӵ��� ������ ����

    void Update()
    {
        // WASD Ű �Է��� �޾� ������ ó��
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������ ������ ���մϴ�.
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // ���� ���� ������Ʈ�� ��ġ�� ������ �̵� ����� �ӵ��� ���Ͽ� ���ο� ��ġ�� ����մϴ�.
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;

        // ���ο� ��ġ�� �̵��մϴ�.
        transform.position = newPosition;
    }
}