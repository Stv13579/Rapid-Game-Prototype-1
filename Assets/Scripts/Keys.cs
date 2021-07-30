using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.tag == "OpenDoorKey")
        {
            Door.GetComponent<Doors>().DoorToggle();
            Destroy(this.gameObject);
        }

        if(collision.tag == "Player" && this.tag == "TeleportKey")
        {
            if(Door.GetComponent<CheckpointDoor>())
            {
               Door.GetComponent<CheckpointDoor>().Dooropen = true;
            }
            if(Door.GetComponent<SceneDoor>())
            {
               Door.GetComponent<SceneDoor>().Dooropen = true;
            }
            Destroy(this.gameObject);
        }
    }
}
