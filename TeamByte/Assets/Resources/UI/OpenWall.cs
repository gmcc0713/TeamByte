using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject circleObj; // Circle 오브젝트의 Transform 참조
    public float interactDistance = 20f; // 허용 거리
    public GameObject playerObj;
    void Update()
    {
        // Circle 오브젝트와의 거리를 계산
        float Walldistance = Vector3.Distance(playerObj.transform.position, circleObj.transform.position);

        if (Walldistance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("대화창 열기");
            OpenScriptUI();
        }
    }
    private void OpenScriptUI()
    {
        Debug.Log("벽 부수기");
        Destroy(wall);
        
    }
}



