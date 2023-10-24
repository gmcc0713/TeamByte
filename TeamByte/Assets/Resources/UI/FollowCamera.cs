using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target; // ī�޶� ���� ���(�÷��̾�)�� Transform ������Ʈ

    void Update()
    {
        if (target != null)
        {
            // �÷��̾��� ��ġ�� ���󰡵��� ī�޶��� ��ġ�� ������Ʈ�մϴ�.
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
