using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneMapOpen : MonoBehaviour
{
    public float interactDistance = 20f; // 허용 거리
    public GameObject KeyObj; // Key 오브젝트의 Transform 참조
    public GameObject playerObj;
    public GameObject CutSceneMap;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Circle 오브젝트와의 거리를 계산
        float Walldistance = Vector3.Distance(playerObj.transform.position, KeyObj.transform.position);

        if (Walldistance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("컷씬용 Map 활성화");
            CutSceneMapActive();

        }
    }

    private void CutSceneMapActive()
    {
        CutSceneMap.SetActive(true);
    }

}

