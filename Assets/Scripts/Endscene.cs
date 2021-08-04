using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscene : MonoBehaviour
{
    public GameObject endScreen;
    public float Duration = 0.4f;
    public CanvasGroup gameover;
    // Update is called once per frame
    void Update()
    {
   
            endScreen.SetActive(true);
            Fade();

    }
    public void Fade()
    {
        StartCoroutine(DoFade(gameover, gameover.alpha, 1));
    }

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }
}
