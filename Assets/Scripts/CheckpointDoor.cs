using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public bool Dooropen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Dooropen == true)
        {
            Player.transform.position = Door.transform.position;
        }
    }
}
