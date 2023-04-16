using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroScreen : MonoBehaviour
{
    public float fadeSpeed = 0.5f; // The speed at which the image will fade in and out
    public KeyCode skipKey = KeyCode.Space; // The key that the player needs to press to skip the intro screen

    [SerializeField] private Image introImage;

    private void Start()
    {
        introImage = GetComponent<Image>();
        introImage.color = new Color(introImage.color.r, introImage.color.g, introImage.color.b, 0); // Set the alpha to 0
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        if (Input.GetKeyDown(skipKey))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        while (introImage.color.a < 1)
        {
            introImage.color = new Color(introImage.color.r, introImage.color.g, introImage.color.b, introImage.color.a + (Time.deltaTime * fadeSpeed));
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        while (introImage.color.a > 0)
        {
            introImage.color = new Color(introImage.color.r, introImage.color.g, introImage.color.b, introImage.color.a - (Time.deltaTime * fadeSpeed));
            yield return null;
        }
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}