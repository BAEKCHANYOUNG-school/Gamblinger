using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangerManger : MonoBehaviour
{
    public string nextSceneName;
    public Image fadeImage;
    public float fadeDuration = 1f;
    float time = 0;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        Debug.Log("페이드 인 시작");
        yield return FadeIn();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            time+= Time.deltaTime;
            if (time > 4f && asyncOperation.progress >= 0.9f)
            {
                Debug.Log("페이드 아웃 시작");
                yield return FadeOut();
                asyncOperation.allowSceneActivation = true;
                Debug.Log("씬 활성화됨");
            }
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Clamp01(elapsedTime / fadeDuration));
            yield return null;
        }
        Debug.Log("페이드 아웃 완료");
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, 1 - Mathf.Clamp01(elapsedTime / fadeDuration));
            yield return null;
        }
        Debug.Log("페이드 인 완료");
    }
}