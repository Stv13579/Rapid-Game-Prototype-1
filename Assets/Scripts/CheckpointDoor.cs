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
    public AnimationCurve curve;
    public float time = 0.0f;

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
        if (time < 1.0f && Dooropen)
        {
            time += Time.deltaTime;
        }


        if (Input.GetKeyDown("e") && inRange)
        {
            if (Player.GetComponent<CharacterMotor>().bigKeys > 0 && Dooropen == false)
            {
                Dooropen = true;
                Player.GetComponent<CharacterMotor>().bigKeys -= 1;
                   this.GetComponent<AudioSource>().Play();

            }
            else if (Dooropen == true)
            {
                Player.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, -1.0f);
                checkpointManager.transform.position = new Vector3(Door.transform.position.x, Door.transform.position.y, -1.0f);
                checkpointManager.GetComponent<CheckpointManager>().torchesLitTotal = checkpointManager.GetComponent<CheckpointManager>().torchesLit;
                checkpointManager.GetComponent<CheckpointManager>().torchesLit = 0;

            }
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, curve.Evaluate(time));

    }
}
