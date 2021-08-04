using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    private GameObject cameraMain;
    private GameObject Player;
    private GameObject checkpointManager;

    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = GameObject.Find("Main Camera");
        Player = GameObject.Find("Character");
        checkpointManager = GameObject.Find("Checkpoint Manager");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && inRange)
        {
            GameEnding();
        }
    }

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

    private void GameEnding()
    {
        Destroy(Player);
        cameraMain.GetComponent<CameraScript>().inGame = false;
        checkpointManager.GetComponent<CheckpointManager>().AllLights();
    }
}
