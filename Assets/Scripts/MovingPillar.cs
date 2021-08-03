using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPillar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform pillar;
    private BoxCollider2D boxCol;
    public AnimationCurve curve;
    public float time = 0.0f;
    public float direction = -1.0f;
    void Start()
    {
        pillar = this.transform.GetChild(0);
        boxCol = pillar.gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * direction;
        time = Mathf.Clamp(time, 0.0f, 1.0f);


        pillar.localPosition = new Vector3(0.0f, curve.Evaluate(time), 0.0f);
        boxCol.size = new Vector2(boxCol.size.x, -curve.Evaluate(1 - time));
        boxCol.offset = new Vector2(boxCol.offset.x, -curve.Evaluate(time) / 2);
    }

    public void movePillar()
    {
        direction *= -1.0f;
    }
}
