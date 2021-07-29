using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform TrackTransform;

    public Vector3 offset = new Vector3(0.0f, 5.0f, -10.0f);
    public float speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TrackTransform.position + offset, speed * Time.deltaTime);
    }
}
