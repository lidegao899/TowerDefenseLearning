using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private IEnumerator FadeIn()
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

    private IEnumerator FadeOut(string scene)
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