using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OutLine") || (collision.gameObject.CompareTag("Enemy")&& !collision.gameObject.GetComponent<Monster>()._IsDie))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Monster>().GetDamage(10);
        }
    }
}
