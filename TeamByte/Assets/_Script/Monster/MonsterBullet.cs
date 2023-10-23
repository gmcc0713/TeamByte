using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float moveSpeed;
    public bool isRun;

    public void HPChange()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRun) return;
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    
}
