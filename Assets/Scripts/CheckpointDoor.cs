using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public bool Dooropen = false;
    public GameObject checkpointManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Dooropen == true)
        {
            Player.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, -1.0f);
            checkpointManager.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, -1.0f);
        }
    }

    private void Start()
    {
        checkpointManager = GameObject.Find("Checkpoint Manager");
    }
}
