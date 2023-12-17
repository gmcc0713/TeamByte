using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;
    private bool isReload = false;

    public float bulletSpeed = 10.0f;
    public int curBulletCount;
    public int maxBullet = 10;
    private float reloadTime = 3.0f;
    public float currentHearts;

    public Text bulletCountText;
    public Text reloadText;
    public GameObject bulletPrefab;
    Rigidbody2D playerRb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    //
    Vector3 dirVec;
    GameObject scanObject;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        reloadText.enabled = false;
        isReload = false;
        curBulletCount = maxBullet;
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player hpValueFromPlayer = FindObjectOfType<Player>();
        if (hpValueFromPlayer != null)
        {
            float currnetHearts = hpValueFromPlayer.f_currentHearts;
        }
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateBulletCountUI();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();

        Scan();

        if (isReload)
        {
            return;
        }

        if (curBulletCount <= 0)
        {
            StartCoroutine(ReloadBullet());
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
            curBulletCount--;
            UpdateBulletCountUI();
        }
    }
    IEnumerator ReloadBullet()
    {
        reloadText.enabled = true;
        isReload = true;
        yield return new WaitForSeconds(reloadTime);
        curBulletCount = maxBullet;
        UpdateBulletCountUI();
        reloadText.enabled = false;
        isReload = false;
    }

    void Move()
    {
        //        horizontalInput =  Input.GetAxisRaw("Horizontal");
        //        verticalInput =  Input.GetAxisRaw("Vertical");
        horizontalInput = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        verticalInput = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        Vector3 playerMove = new Vector3(horizontalInput, verticalInput, 0.0f).normalized;
        Vector3 moveDistance = playerMove * speed * Time.deltaTime;

        transform.Translate(moveDistance);

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Walk", true);
            //
            dirVec = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);
            //
            dirVec = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Walk", true);
            //
            dirVec = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Walk", true);
            //
            dirVec = Vector3.down;
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

        //
        if(Input.GetKeyDown(KeyCode.Space) && scanObject !=null)
        {
            manager.Action(scanObject);
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
        else if (gameObject.transform.position.x > mousePosition.x && !spriteRenderer.flipX)
        {
            newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletRb = newBullet.GetComponent<Rigidbody2D>();
            // 플레이어가 -방향을 보고 있을 때는 반대 방향으로 발사
            bulletRb.velocity = shootDirection * bulletSpeed;
        }

    }

    private void Scan()
    {
        //Ray
        Debug.DrawRay(playerRb.position, dirVec * 0.7f, new Color(1, 1, 1));
        RaycastHit2D rayHit = Physics2D.Raycast(playerRb.position, dirVec, 1.0f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

    void UpdateBulletCountUI()
    {
        bulletCountText.text = "Bullet : " + curBulletCount.ToString();
    }
}