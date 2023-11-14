using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject player;
    public SceneData data = new SceneData();
    private void Start()
    {
        Debug.Log(data.stage4Position);
    }
    // Update is called once per frame
    void Update()
    {
       

        if (data.stage4Position == true)
        {
            player.transform.position = this.transform.position;
        }
       
    }
}
