using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    public int currentScene; // Scene 이름 저장
    public Save_Data data;
    public void Start()
    {
        
    }

    // 충돌 발생 시 호출될 함수
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌");
            SaveLoadManager.Instance.SetNextScene((int)data);
            SaveLoadManager.Instance.NextSceneStart();
           
        }
    }
}
