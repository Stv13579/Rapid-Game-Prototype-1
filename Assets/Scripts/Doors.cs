using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Transform doorTop;
    private Transform doorBottom;
    private BoxCollider2D doorTopCol;
    private BoxCollider2D doorBottomCol;
    private GameObject player;
    public bool inRange = false;
    public float direction = -1.0f;
    public AnimationCurve curve;
    public float time = 0.0f;
    private void Start()
    {
        doorTop = this.transform.GetChild(1);
        doorBottom = this.transform.GetChild(2);

        doorTopCol = doorTop.gameObject.GetComponent<BoxCollider2D>();
        doorBottomCol = doorBottom.gameObject.GetComponent<BoxCollider2D>();

        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * direction;
        time = Mathf.Clamp(time, 0.0f, 1.0f);
        if (Input.GetKeyDown("e") && inRange)
        {
            if (player.GetComponent<CharacterMotor>().smallKeys > 0)
            {
                DoorToggle();
                player.GetComponent<CharacterMotor>().smallKeys -= 1;
            }
        }
        doorTop.localPosition = new Vector3(0.0f, curve.Evaluate(time), 0.0f);
        doorTopCol.size = new Vector2(doorTopCol.size.x, curve.Evaluate(1 - time));
        doorTopCol.offset = new Vector2(doorTopCol.offset.x, curve.Evaluate(1 - time) / 2);

        doorBottom.localPosition = new Vector3(0.0f, -curve.Evaluate(time), 0.0f);
        doorBottomCol.size = new Vector2(doorBottomCol.size.x, curve.Evaluate(1 - time));
        doorBottomCol.offset = new Vector2(doorBottomCol.offset.x, -curve.Evaluate(1 - time) / 2);
    }

    public void DoorToggle()
    {
        direction *= -1.0f;
        this.GetComponent<AudioSource>().Play();
        if (this.transform.childCount >= 4)
        {
            this.transform.GetChild(3).gameObject.SetActive(false);
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
}
