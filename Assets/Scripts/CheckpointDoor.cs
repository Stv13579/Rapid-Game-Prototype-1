using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public bool Dooropen = false;
    public GameObject checkpointManager;
    public bool inRange;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (Dooropen == true)
    //    {

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void Start()
    {
        checkpointManager = GameObject.Find("Checkpoint Manager");
    }

    private void Update()
    {
        if (Dooropen && this.gameObject.GetComponent<SpriteRenderer>().color.a > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.0f, 0.0f, 0.01f);
        }

        if (Input.GetKeyDown("e") && inRange)
        {
            if (Player.GetComponent<CharacterMotor>().bigKeys > 0 && Dooropen == false)
            {
                Dooropen = true;
                Player.GetComponent<CharacterMotor>().bigKeys -= 1;
            }
            else if (Dooropen == true)
            {
                Player.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, -1.0f);
                checkpointManager.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, -1.0f);
            }
        }
    }
}
