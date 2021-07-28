using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light spotLight;
    // Start is called before the first frame update
    void Start()
    {
        spotLight = transform.GetChild(0).gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LightToggle();
            Debug.Log("Test");
        }
    }

    void LightToggle()
    {
        spotLight.enabled = !spotLight.enabled;
    }
}
