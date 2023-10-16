using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OutLine") || collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collide");
            Destroy(gameObject);
        }
    }
}
