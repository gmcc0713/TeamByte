using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    public int currentScene; // Scene �̸� ����
    public Save_Data data;
    public void Start()
    {
        
    }

    // �浹 �߻� �� ȣ��� �Լ�
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�浹");
            SaveLoadManager.Instance.SetNextScene((int)data);
            SaveLoadManager.Instance.NextSceneStart();
           
        }
    }
}
