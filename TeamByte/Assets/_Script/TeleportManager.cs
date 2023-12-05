using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject[] teleportPoints;
    GameObject randomPoint;

    public float teleportCooldown = 2f;
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport && other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TeleportCooldown());
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        randomPoint = teleportPoints[Random.Range(0, teleportPoints.Length)];
        player.transform.position = randomPoint.transform.position;
    }

    // ���� �ð� ���� �浹 ������ �����ϱ� ���� �ڷ�ƾ
    private System.Collections.IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}
