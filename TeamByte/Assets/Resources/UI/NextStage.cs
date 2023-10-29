using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    private string currentScene; // Scene 이름 저장

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }

    // 충돌 발생 시 호출될 함수
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌");
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
