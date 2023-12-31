using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    public bool InteractionValue; // 연출을 위한 bool 값

    public GameObject Destorywall;
    public GameObject ActiveWall;
    public GameObject WallKeyObj; // Circle 오브젝트의 Transform 참조
    public float interactDistance = 20f; // 허용 거리
    public GameObject playerObj;

    private void Start()
    {
        InteractionValue = false;
    }
    void Update()
    {
        // Circle 오브젝트와의 거리를 계산
        float Walldistance = Vector3.Distance(playerObj.transform.position, WallKeyObj.transform.position);

        if (Walldistance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("대화창 열기");
            OpenScriptUI();
        }
    }
    private void OpenScriptUI()
    {
        Debug.Log("벽 부수기");
        Destroy(Destorywall);
        ActiveWall.SetActive(true);
        InteractionValue = true;
    }
}



