using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ���(�÷��̾�)�� Transform ������Ʈ

    public float lerpTime = 2f; // ������ ���� �ð�

    public float CameraHeight; // ī�޶� ������ ����
    public float CameraWidth; // ī�޶� ������ ����


    public Tilemap tilemap;
    public Vector3 mapSize;

    private void Start()
    {
        // ī�޶�
        CameraHeight = Camera.main.orthographicSize;
        CameraWidth = CameraHeight * Screen.width / Screen.height;

        // ���� TileMap�� ������� ���� ũ�⸦ ���
        //BoundsInt bounds = tilemap.cellBounds;
        //mapSize = new Vector3(bounds.size.x, bounds.size.y, 0f);
    }

    void Update()
    {
        if (target != null)
        {
           // Ÿ�� ��ġ ����
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // ���� ī�޶� position
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);

        }
    }

    // ���� ���� �� ����
    /*
    public Transform target; // ī�޶� ���� ���(�÷��̾�)�� Transform ������Ʈ
    public float lerpTime = 1.0f; // ������ ���� �ð�

    public Tilemap groundTilemap;
    private Vector3 mapSize;
    private float cameraHeight;
    private float cameraWidth;

    public Camera followCamera;

    void Start()
    {

        // ī�޶��� ���̿� �ʺ� �ʱ�ȭ
        cameraHeight = followCamera.orthographicSize;
        cameraWidth = cameraHeight * followCamera.aspect;

        // Ground Tilemap�� ũ�� ���
        BoundsInt bounds = groundTilemap.cellBounds;
        mapSize = new Vector3(bounds.size.x, bounds.size.y, 0f);
        Debug.Log(mapSize);
    }

    void Update()
    {
        if (target != null)
        {
            // Ÿ���� ��ġ�� ī�޶��� x, y ��ǥ�� �����Ͽ� ���ο� ��ġ ���͸� ����
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            float groundX = mapSize.x / 2;
            float groundY = mapSize.y / 2;

            // ������ ���ο� ī�޶� ��ġ�� �����Ͽ� Ground Tilemap ���� ���� �ӹ��� �� �ֵ��� ��
            float clampX = Mathf.Clamp(targetPosition.x, 88.75f, 113.25f);
            float clampY = Mathf.Clamp(targetPosition.y, -33f, 7.05f);

            // ���ο� ��ġ�� �����Ͽ� ī�޶� �̵�
            transform.position = Vector3.Lerp(transform.position, new Vector3(clampX, clampY, targetPosition.z), lerpTime * Time.deltaTime);
        }
    }
    */
}
