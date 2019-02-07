using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenechange : MonoBehaviour
{

    [SerializeField]
    GameObject text;
    Image t;
    float alpha;
    float blackalpha;
    float elapsedTime;

    [SerializeField]
    private Image _blackImage;

    bool done = false;

    // Use this for initialization
    void Start()
    {
        t = text.GetComponent<Image>();
        alpha = 1;
        blackalpha = 0.01f;

        StartCoroutine(MainCoroutine());
        StartCoroutine(DisplayTouchToPlay());
        
    }

    IEnumerator MainCoroutine()
    {
        AsyncOperation async;

        while (true)
        {
            if (AppUtil.GetTouchInfo() == TouchInfo.Began)
            {
                break;
            }

            yield return null;
        }

        while (blackalpha < 1)
        {
            _blackImage.GetComponent<Image>().color = new Color(0, 0, 0, blackalpha);

            blackalpha += 0.01f;

            yield return null;
        }

        async = SceneManager.LoadSceneAsync("Home");

        async.allowSceneActivation = false;    // シーン遷移をしない

        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);

            yield return null;
        }

        Debug.Log("Scene Loaded");
        StopCoroutine(DisplayTouchToPlay());
        async.allowSceneActivation = true;    // シーン遷移許可

        while (true)
        {
            yield return null;
        }
    }

    IEnumerator DisplayTouchToPlay()
    {
        while (true)
        {
            elapsedTime += Time.deltaTime;
            alpha = Mathf.Abs(Mathf.Cos(elapsedTime * 0.7f));

            t.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

}
