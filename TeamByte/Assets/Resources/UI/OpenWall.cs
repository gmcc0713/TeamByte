using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject circleObj; // Circle ������Ʈ�� Transform ����
    public float interactDistance = 20f; // ��� �Ÿ�
    public GameObject playerObj;
    void Update()
    {
        // Circle ������Ʈ���� �Ÿ��� ���
        float Walldistance = Vector3.Distance(playerObj.transform.position, circleObj.transform.position);

        if (Walldistance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("��ȭâ ����");
            OpenScriptUI();
        }
    }
    private void OpenScriptUI()
    {
        Debug.Log("�� �μ���");
        Destroy(wall);
        
    }
}



