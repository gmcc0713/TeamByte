using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target; // ī�޶� ���� ���(�÷��̾�)�� Transform ������Ʈ

    public float lerpTime = 1.0f; // ������ ���� �ð�

    void Update()
    {
        if (target != null)
        {
            // �÷��̾��� ��ġ�� ���󰡵��� ī�޶��� ��ġ�� ������Ʈ�մϴ�.
            //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Ÿ���� ��ġ�� ī�޶��� x, y ��ǥ�� �����Ͽ� ���ο� ��ġ ���͸� ����
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // ���� ī�޶��� ��ġ���� Ÿ���� ��ġ�� ������ �����Ͽ� ���ο� ī�޶��� ��ġ�� ���
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);

        }
    }
}
