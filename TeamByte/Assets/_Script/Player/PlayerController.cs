using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Walk", true);
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.speed = 1f;
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.speed = 1f;
        }
    }
    void FireBullet()
    {
        // �Ѿ��� �����ϰ� �ʱ� ��ġ�� �÷��̾� ��ġ�� ����
        GameObject newBullet;
        Rigidbody2D bulletRb;

        // �Ѿ˿� Rigidbody2D ������Ʈ�� ������

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 Ŀ�� ��ġ�� ���� ���� ��ǥ�� ��ȯ
        Vector2 shootDirection = (mousePosition - (Vector2)transform.position).normalized; // �÷��̾�� ���콺 Ŀ�� ������ ����

        if (gameObject.transform.position.x < mousePosition.x && spriteRenderer.flipX)
        {
            newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletRb = newBullet.GetComponent<Rigidbody2D>();
            // �÷��̾ +������ ���� ���� ���� �߻�
            bulletRb.velocity = shootDirection * bulletSpeed;
        }
        else if (gameObject.transform.position.x > mousePosition.x && !spriteRenderer.flipX)
        {
            newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletRb = newBullet.GetComponent<Rigidbody2D>();
            // �÷��̾ -������ ���� ���� ���� �ݴ� �������� �߻�
            bulletRb.velocity = shootDirection * bulletSpeed;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("EnemyBullet"))
        {
            
        }
    }
}