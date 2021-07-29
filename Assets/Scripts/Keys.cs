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
            Door.GetComponent<CheckpointDoor>().Dooropen = true;
            Destroy(this.gameObject);
        }
    }
}
