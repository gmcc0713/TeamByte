using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float moveSpeed;
    public bool isRun;

    public int bounceCount;
    public bool isBounceType;
    public Vector2 velocity;

    public void HPChange()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5f);
        velocity = Vector2.right;

    }
    void CollideWallAndChangeVelocity()
    {
        velocity = new Vector2(-velocity.y, velocity.x);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isRun) return;
        transform.Translate(velocity * Time.deltaTime * moveSpeed);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            CollideWallAndChangeVelocity();
        }
    }
}
