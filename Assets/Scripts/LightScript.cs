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

    }

    public void LightToggle() //Toggles the light off and on
    {
        spotLight.enabled = !spotLight.enabled;
    }
}
