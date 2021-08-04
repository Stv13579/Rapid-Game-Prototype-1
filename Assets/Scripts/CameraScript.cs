using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform TrackTransform;
    public Vector3 offset = new Vector3(0.0f, 5.0f, -10.0f);
    public float speed = 8.0f;
    public bool inGame = true;
    private GameObject checkpoint;
    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            transform.position = Vector3.Lerp(transform.position, TrackTransform.position + offset, speed * Time.deltaTime);
            this.GetComponent<Camera>().orthographicSize = ((checkpoint.GetComponent<CheckpointManager>().torchesLit + checkpoint.GetComponent<CheckpointManager>().torchesLitTotal) / 9) + 3;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(35.0f, -50.0f, transform.position.z), Time.deltaTime / 2.0f);
            if (this.GetComponent<Camera>().orthographicSize <= 50.0f)
            {
                this.GetComponent<Camera>().orthographicSize += 2.0f * Time.deltaTime;
            }
            if (this.GetComponent<Camera>().orthographicSize >= 30.0f)
            {
                checkpoint.GetComponent<CheckpointManager>().dimLights();
            }
        }
    }
    private void Start()
    {
        checkpoint = GameObject.Find("Checkpoint Manager");
    }
}
