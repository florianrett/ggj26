using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Image fadeImage;

    [SerializeField] private float fadeTime;

    void Awake()
    {
        SetFadeValue(1);
    }

    private void Start()
    {
        StartScreenFade(true);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        
        SceneManager.LoadScene(sceneName);
    }

    // Set the screen fade value, 0 being fully transparent and 1 being fully opaque
    void SetFadeValue(float alpha)
    {
        fadeImage.color = new Color(0, 0, 0, alpha);
    }

    void StartScreenFade(bool bFadeIn)
    {
        StartCoroutine(bFadeIn ? FadeIn() : FadeOut());
    }

    IEnumerator FadeOut()
    {
        SetFadeValue(0);
        
        float timePassed = 0;
        while (timePassed < fadeTime)
        {
            yield return new WaitForEndOfFrame();
            
            timePassed += Time.deltaTime;
            SetFadeValue(timePassed / fadeTime);
        }
        
        SetFadeValue(1);
    }

    IEnumerator FadeIn()
    {
        SetFadeValue(1);
        
        float timePassed = 0;
        while (timePassed < fadeTime)
        {
            yield return new WaitForEndOfFrame();
            
            timePassed += Time.deltaTime;
            SetFadeValue(1 - timePassed / fadeTime);
        }
        
        SetFadeValue(0);
    }
}
