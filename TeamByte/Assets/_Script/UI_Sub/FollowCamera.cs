using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상(플레이어)의 Transform 컴포넌트

    public float lerpTime = 2f; // 보간에 사용될 시간

    public float CameraHeight; // 카메라 높이의 절반
    public float CameraWidth; // 카메라 넓이의 절반


    public Tilemap tilemap;
    public Vector3 mapSize;

    private void Start()
    {
        // 카메라
        CameraHeight = Camera.main.orthographicSize;
        CameraWidth = CameraHeight * Screen.width / Screen.height;

        // 맵의 TileMap을 기반으로 맵의 크기를 계산
        //BoundsInt bounds = tilemap.cellBounds;
        //mapSize = new Vector3(bounds.size.x, bounds.size.y, 0f);
    }

    void Update()
    {
        if (target != null)
        {
           // 타깃 위치 보간
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // 최종 카메라 position
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpTime * Time.deltaTime);

        }
    }

    // 보간 수정 후 적용
    /*
    public Transform target; // 카메라가 따라갈 대상(플레이어)의 Transform 컴포넌트
    public float lerpTime = 1.0f; // 보간에 사용될 시간

    public Tilemap groundTilemap;
    private Vector3 mapSize;
    private float cameraHeight;
    private float cameraWidth;

    public Camera followCamera;

    void Start()
    {

        // 카메라의 높이와 너비 초기화
        cameraHeight = followCamera.orthographicSize;
        cameraWidth = cameraHeight * followCamera.aspect;

        // Ground Tilemap의 크기 계산
        BoundsInt bounds = groundTilemap.cellBounds;
        mapSize = new Vector3(bounds.size.x, bounds.size.y, 0f);
        Debug.Log(mapSize);
    }

    void Update()
    {
        if (target != null)
        {
            // 타겟의 위치를 카메라의 x, y 좌표로 보간하여 새로운 위치 벡터를 생성
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            float groundX = mapSize.x / 2;
            float groundY = mapSize.y / 2;

            // 보간된 새로운 카메라 위치를 제한하여 Ground Tilemap 범위 내에 머무를 수 있도록 함
            float clampX = Mathf.Clamp(targetPosition.x, 88.75f, 113.25f);
            float clampY = Mathf.Clamp(targetPosition.y, -33f, 7.05f);

            // 새로운 위치를 적용하여 카메라를 이동
            transform.position = Vector3.Lerp(transform.position, new Vector3(clampX, clampY, targetPosition.z), lerpTime * Time.deltaTime);
        }
    }
    */
}
