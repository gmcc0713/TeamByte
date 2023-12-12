using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneObject : MonoBehaviour
{
    public GameManager gameManager;
    public int cutSceneId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            gameManager.CutSceneAction(cutSceneId);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
    }
}
