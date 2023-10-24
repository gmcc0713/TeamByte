using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    public Transform stage1;
    public Transform stage2;
    public Transform stage3;
    public Transform stage4;

    public Transform Player;


    // 충돌 발생 시 호출될 함수
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("충돌");
            string parentName = transform.parent.name;
            if (parentName == "Tutorial")
                Player.transform.position = new Vector2(280, -40);
            if (parentName == "Stage1")
                Player.transform.position = new Vector2(516, -71);
            if (parentName == "Stage2")
                Player.transform.position = new Vector2(678,-41);
            if (parentName == "Stage3")
                Player.transform.position = new Vector2(884,-41);
            if (parentName == "Stage4")
                SceneManager.LoadScene("EndingScene");


        }
  
    }


}
