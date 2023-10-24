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
        if (collision.gameObject.CompareTag("OutLine"))
        {
            
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
            animator.SetTrigger("Walk");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = true;
            animator.SetTrigger("Walk");
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
        GameObject newBullet;
        Rigidbody2D bulletRb;

        // 총알에 Rigidbody2D 컴포넌트를 가져옴

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 커서 위치를 게임 월드 좌표로 변환
        Vector2 shootDirection = (mousePosition - (Vector2)transform.position).normalized; // 플레이어에서 마우스 커서 방향을 구함

        if (gameObject.transform.position.x < mousePosition.x && spriteRenderer.flipX)
        {
            newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletRb = newBullet.GetComponent<Rigidbody2D>();
            // 플레이어가 +방향을 보고 있을 때만 발사
            bulletRb.velocity = shootDirection * bulletSpeed;
        }
        else if(gameObject.transform.position.x > mousePosition.x && !spriteRenderer.flipX)
        {
            newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletRb = newBullet.GetComponent<Rigidbody2D>();
            // 플레이어가 -방향을 보고 있을 때는 반대 방향으로 발사
            bulletRb.velocity = shootDirection * bulletSpeed;
        }
        
    }
}