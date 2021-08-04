using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointManager : MonoBehaviour
{
    public GameObject[] torches;
    public int torchesLit = 0;
    public int torchesLitTotal = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            torchesLit = 0;
        }
    }
    public void AllLights()
    {
        torches = GameObject.FindGameObjectsWithTag("Torch");
        foreach (GameObject torch in torches)
        {
            torch.GetComponent<Torch>().activate();
        }
    }

    public void dimLights()
    {
        foreach (GameObject torch in torches)
        {
            torch.transform.GetChild(1).gameObject.GetComponent<Light>().intensity -= 12 * Time.deltaTime;
        }
    }
}
