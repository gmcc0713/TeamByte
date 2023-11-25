using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpinSquareBullet : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 9f;
    [SerializeField] private float curSpeed;
    // Start is called before the first frame update
    void Start()
    {
        curSpeed = rotateSpeed;
        transform.rotation =Quaternion.Euler(new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f, curSpeed * Time.deltaTime));
    }
    public void AddSpeed(float add)
    {
        curSpeed += add;
    }
    public void ResetSpeed()
    {
        curSpeed = rotateSpeed;
    }

}
