using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Transform Door;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {

    }
    public void DoorOpen()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Keys>().TeleportKey == true)
        {
            Player.transform.position = Door.transform.position;
        }
    }
}
