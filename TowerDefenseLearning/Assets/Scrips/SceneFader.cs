using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public Image image;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string strScene)
    {
        StartCoroutine(FadeOut(strScene));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;
        while (time > 0)
        {
            time -= Time.deltaTime;
            float alfa = curve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, alfa);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0f;
        while (time < 1)
        {
            time += Time.deltaTime;
            float alfa = curve.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, alfa);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
