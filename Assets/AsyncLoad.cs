using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoad : MonoBehaviour
{

    [SerializeField]
    Text _loadingText;
    [SerializeField]
    Image _loadingBar;

    void Start()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void LoadSceneAsync(string loadSceneName)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadSceneCoroutine(loadSceneName));
    }

    IEnumerator LoadSceneCoroutine(string loadSceneName)
    {
        var async = SceneManager.LoadSceneAsync(loadSceneName);
        if (Time.timeScale != 0)
        {
            async.allowSceneActivation = false;    // シーン遷移をしない

            _loadingText.text = "0%";
            yield return null;

            while (async.progress < 0.9f)
            {
                Debug.Log(async.progress);
                _loadingText.text = (async.progress * 100).ToString("F0") + "%";
                _loadingBar.fillAmount = async.progress;
                yield return null;
            }

            Debug.Log("Scene Loaded");

            _loadingText.text = "100%";
            _loadingBar.fillAmount = 1;

            yield return null;
        }

        async.allowSceneActivation = true;    // シーン遷移許可
        yield return null;

        yield return null;
    }
}
