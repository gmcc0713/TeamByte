using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signScript : MonoBehaviour
{
    public string signString; // ǥ���� �ȳ���
    public GameObject signObj;
    public float interactDistance = 20f; // ��� �Ÿ�
    public GameObject playerObj;

    public void Start()
    {
        signString = "abc";
    }



    void Update()
    {
        float Walldistance = Vector3.Distance(playerObj.transform.position, signObj.transform.position);

        if (Walldistance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            SayString();
        }
    }
    public void SayString()
    {
        Debug.Log(signString);
    }

}
