using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    public float bulletSpeed = 10f;

    public GameObject bulletPrefab;
    Rigidbody2D playerRb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collide");
            Destroy(gameObject);
        }
    }

    void Move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 playerMove = new Vector3(horizontalInput, verticalInput, 0.0f).normalized;
        Vector3 moveDistance = playerMove * speed * Time.deltaTime;

        transform.Translate(moveDistance);

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = true;
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.speed = 0f;
        }
        else
        {
            animator.speed = 1f;
        }
    }
    void FireBullet()
    {
        // 총알을 생성하고 초기 위치를 플레이어 위치로 설정
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 총알에 Rigidbody2D 컴포넌트를 가져옴
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        // 플레이어가 바라보는 방향으로 총알 발사
        Vector2 shootDirection = new Vector2(horizontalInput, verticalInput).normalized;
        bulletRb.velocity = shootDirection * bulletSpeed;
    }
}
