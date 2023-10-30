using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    private string currentScene; // Scene �̸� ����

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }

    // �浹 �߻� �� ȣ��� �Լ�
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�浹");
            string currentScene = transform.parent.name;
            if (currentScene == "Tutorial")
                SceneManager.LoadScene("Stage1");
            if (currentScene == "Stage1")
                SceneManager.LoadScene("Stage2");
            if (currentScene == "Stage2")
                SceneManager.LoadScene("Stage3");
            if (currentScene == "Stage3")
                SceneManager.LoadScene("Stage4");
            if (currentScene == "Stage4")
                SceneManager.LoadScene("EndingScene");
        }
    }
}
