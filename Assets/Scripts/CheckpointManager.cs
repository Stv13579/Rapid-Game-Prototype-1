using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointManager : MonoBehaviour
{
    public GameObject[] torches;
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
        }
        if (Input.GetKeyDown("space"))
        {
            torches = GameObject.FindGameObjectsWithTag("Torch");
            foreach (GameObject torch in torches)
            {
                torch.GetComponent<Torch>().activate();
            }
        }

    }
}
