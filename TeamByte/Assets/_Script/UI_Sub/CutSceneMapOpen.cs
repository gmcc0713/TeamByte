using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneMapOpen : MonoBehaviour
{
    public float interactDistance = 20f; // ��� �Ÿ�
    public GameObject KeyObj; // Key ������Ʈ�� Transform ����
    public GameObject playerObj;
    public GameObject CutSceneMap;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Circle ������Ʈ���� �Ÿ��� ���
        float Walldistance = Vector3.Distance(playerObj.transform.position, KeyObj.transform.position);

        if (Walldistance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("�ƾ��� Map Ȱ��ȭ");
            CutSceneMapActive();

        }
    }

    private void CutSceneMapActive()
    {
        CutSceneMap.SetActive(true);
    }

}

