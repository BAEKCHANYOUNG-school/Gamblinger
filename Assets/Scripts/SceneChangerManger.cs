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
        Debug.Log("���̵� �� ����");
        yield return FadeIn();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            time+= Time.deltaTime;
            if (time > 4f && asyncOperation.progress >= 0.9f)
            {
                Debug.Log("���̵� �ƿ� ����");
                yield return FadeOut();
                asyncOperation.allowSceneActivation = true;
                Debug.Log("�� Ȱ��ȭ��");
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
        Debug.Log("���̵� �ƿ� �Ϸ�");
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
        Debug.Log("���̵� �� �Ϸ�");
    }
}